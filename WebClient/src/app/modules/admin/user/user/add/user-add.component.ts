import { Component, ViewChild } from '@angular/core';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { DepartmentHttpService } from 'src/services/http/user/department-http.service';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { PermissionComponent } from '../../permission/permission.component';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html'
})
export class UserAddComponent extends FormComponent {

  loading: boolean = true;
  roleList = [];
  designations = [];
  departments = [];
  statuses = []
  userOption = 'add_edit'
  addEditTitle;

  @ViewChild("permission") permissionComponent: PermissionComponent;

  private permissionIds;

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

  async ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      employeeId: [],
      designation: [null, [], this.v.required.bind(this)],
      department: [],
      mobile: [null, [], this.v.mobile.bind(this)],
      email: [null, [], this.v.email.bind(this)],
      password: [null, [], this.password.bind(this)],
      roles: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

    const user = await this.t('user');
    if (this.mode == 'add') {
      this.addEditTitle = await this.t('create.a.x0', { x0: user });
    }
    else if (this.mode == 'edit') {
      this.addEditTitle = await this.t('update.a.x0', { x0: user });
    }
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (this.id) {
      body.id = Number(this.id);
    }

    const permissions = this.getPermissions();
    if (permissions && permissions.length > 0) {
      body.permissions = permissions;
    }
    this.submitForm(
      {
        request: this.userHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.userHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
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
          this.designations = res[1].data.items.sort((a, b) => (a.name > b.name) ? 1 : ((b.name > a.name) ? -1 : 0)),
          this.departments = res[2].data.items,
          this.roleList = res[3].data.items

      }
    );
  }

  onChangePermissions(permissions) {
    this.permissionIds = permissions;
    this.log('permissions', permissions);
  }

  private getPermissions() {
    if (this.permissionComponent) {
      const _permissionIds = [];
      this.permissionComponent.getPermissions(_permissionIds);
      this.permissionIds = _permissionIds;
    }
    return this.permissionIds;
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
