import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/designation-http.service';
import { DepartmentHttpService } from 'src/services/http/department-http.service';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MessageKey } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html'
})
export class UserAddComponent extends FormComponent {

  loading: boolean = true;
  roles = [];
  designations = [];
  departments = [];
  statuses = []

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private commonHttpService: CommonHttpService,
    private designationHttpService: DesignationHttpService,
    private departmentHttpService: DepartmentHttpService,
    private roleHttpService: RoleHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      employeeId: [null, [], this.v.required.bind(this)],
      designation: [null, [], this.v.required.bind(this)],
      department: [],
      mobile: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.password.bind(this)],
      roles: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.userHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.userHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (this.mode == "edit") {
      this.form.controls.email.disable();
    }
    if (id != null) {
      this.subscribe(this.userHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.form.controls.status.setValue(res.data.status?.id);
          this.form.controls.designation.setValue(res.data.designation?.id);
          this.form.controls.department.setValue(res.data.department?.id);
          this.form.controls.roles.setValue(res.data.roles.map(x => x.id))
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.status.setValue(1);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/users');
  }

  getData() {
    const requests = [
      this.commonHttpService.getStatusList(),
      this.designationHttpService.list(),
      this.departmentHttpService.list(),
      this.roleHttpService.list(),
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.statuses = res[0].data.items,
          this.designations = res[1].data.items,
          this.departments = res[2].data.items,
          this.roles = res[3].data.items
      }
    );
  }

  private password(control: FormControl) {
    if (this.mode == 'add' || control.value) {
      if (!control.value) {
        return this.error(MessageKey.THIS_FIELD_IS_REQUIRED);
      }
      else if (control.value.length < 4) {
        return this.error(MessageKey.MUST_BE_EQUAL_OR_GREATER_THAN_4_CHARACTERS);
      }
    }
    return of(true);
  }


}
