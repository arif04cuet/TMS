import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@Component({
  selector: 'app-member-request',
  templateUrl: './member-request.component.html'
})
export class MemberRequestComponent extends FormComponent {

  loading: boolean = true;
  libraries = [];

  private data: any = {}

  constructor(
    private activatedRoute: ActivatedRoute,
    private libraryHttpService: LibraryHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      mobile: [null, [], this.v.mobile.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.password.bind(this)],
      library: [null, [], this.v.required.bind(this)],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (this.isEditMode()) {
      body.userId = Number(this.data.userId);
    }
    this.submitForm(
      {
        request: this.libraryMemberHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.libraryMemberHttpService.edit(this.id, body),
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
      this.form.controls.email.disable();
      this.subscribe(this.libraryMemberHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.status.setValue(3);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/members');
  }

  getData() {
    const requests = [
      this.libraryHttpService.list()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.libraries = res[0].data.items;
      }
    );
  }

  private password(control: FormControl) {
    if (this.mode == 'add' || control.value) {
      if (!control.value) {
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
      else if (control.value.length < 4) {
        return this.error(MESSAGE_KEY.MUST_BE_EQUAL_OR_GREATER_THAN_4_CHARACTERS);
      }
    }
    return of(true);
  }

}
