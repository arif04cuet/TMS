import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@Component({
  selector: 'app-library-add',
  templateUrl: './library-add.component.html'
})
export class LibraryAddComponent extends FormComponent {

  loading: boolean = true;
  users = [];
  districts = [];

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private libraryHttpService: LibraryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      librarian: [null, [], this.v.required.bind(this)],
      addressLine1: [],
      addressLine2: [],
      upazila: [],
      district: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.mapRequestData(body);
    this.submitForm(
      {
        request: this.libraryHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.libraryHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.libraryHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.mapResponseData(res.data);
          this.form.controls.librarian.setValue(res.data.librarian?.id);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/libraries');
  }

  getData() {
    const requests = [
      this.userHttpService.list()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.users = res[0].data.items;
      }
    );
  }

  optionChanged(e) {

  }

  private mapRequestData(o) {
    o.address = {
      addressLine1: o.addressLine1,
      addressLine2: o.addressLine2,
      upazila: o.upazila,
      district: o.district?.id
    }
  }

  private mapResponseData(data) {
    if (data.address) {
      this.setValue('addressLine1', data.address?.addressLine1);
      this.setValue('addressLine2', data.address?.addressLine2);
      this.setValue('contactName', data.address?.contactName);
      this.setValue('upazila', data.address?.upazila);
      this.setValue('district', data.address?.district?.id);
    }
  }


}
