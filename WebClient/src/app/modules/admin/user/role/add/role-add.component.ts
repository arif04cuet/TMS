import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { PermissionComponent } from '../../permission/permission.component';

@Component({
  selector: 'app-role-add',
  templateUrl: './role-add.component.html'
})
export class RoleAddComponent extends FormComponent {

  loading: boolean = true;
  addEditTitle;

  @ViewChild("permission") permissionComponent: PermissionComponent;

  private permissionIds;

  constructor(
    private activatedRoute: ActivatedRoute,
    private roleHttpService: RoleHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

    const role = await this.t('role');
    if (this.mode == 'add') {
      this.addEditTitle = await this.t('create.a.x0', { x0: role });
    }
    else if (this.mode == 'edit') {
      this.addEditTitle = await this.t('update.a.x0', { x0: role });
    }
  }

  submit(): void {


    const body: any = this.constructObject(this.form.controls);
    const permissions = this.getPermissions();
    if (permissions && permissions.length > 0) {
      body.permissions = permissions;
    }
    this.submitForm(
      {
        request: this.roleHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.roleHttpService.edit(this.id, body),
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
      this.subscribe(this.roleHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/roles');
  }

  onChangePermissions(permissions) {
    this.permissionIds = permissions;
  }

  private getPermissions() {
    if (this.permissionComponent) {
      const _permissionIds = [];
      this.permissionComponent.getPermissions(_permissionIds);
      this.permissionIds = _permissionIds;
    }
    return this.permissionIds;
  }

}
