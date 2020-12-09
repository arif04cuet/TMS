import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { forkJoin } from 'rxjs';
import { forEachObj } from 'src/services/utilities.service';

@Component({
  selector: 'app-rack-add',
  templateUrl: './rack-add.component.html'
})
export class RackAddComponent extends FormComponent {

  loading: boolean = true;
  libraries = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private rackHttpService: RackHttpService,
    private libraryHttpService: LibraryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      floorNo: [null, [], this.v.required.bind(this)],
      buildingName: [null, [], this.v.required.bind(this)],
      library: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {

    const body = this.constructObject(this.form.controls);
    const libraryId = this.form.controls.library.value;
    this.submitForm(
      {
        request: this.rackHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.rackHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  validateForm(fn?: () => void) {
    this.busy();
    this.markDirtyAndCheckValidity(this.form.controls);

    if (this.form.valid) {

      this.subscribe(this.rackHttpService.checkDuplicate(this.form),
        (res: any) => {
          console.log(res);
          if (res.data.items.length > 0)
            this.failed('duplicate');
          else
            this.invoke(fn);

        }
      );
    }
    else {
      this.log('INVALID FORM', this.form);
      this.busy(false);
    }
    return this.form.valid;
  }


  get(id) {
    this.loading = true;
    if (id != null) {
      this.getLibraries();
      this.subscribe(this.rackHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
      this.getLibraries(() => {
        this.selectFirstLibrary();
      });
    }
  }

  getLibraries(fn?) {
    const requests = [
      this.libraryHttpService.list(),
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.libraries = res[0].data.items;
        this.invoke(fn);
      }
    );
  }

  selectFirstLibrary() {
    if (this.libraries.length > 0) {
      this.form.controls.library.setValue(this.libraries[0].id);
    }
  }

  cancel() {
    this.goTo('/admin/library/racks');
  }

}
