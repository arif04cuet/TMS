import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAddComponent } from './user-add.component';
import { UserHttpService } from 'src/services/http/user-http.service';
import { UserAddRoutingModule } from './user-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/designation-http.service';
import { DepartmentHttpService } from 'src/services/http/department-http.service';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { PermissionModule } from '../../permission/permission.module';

@NgModule({
  declarations: [
    UserAddComponent
  ],
  imports: [
    UserAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PermissionModule
  ],
  exports: [UserAddComponent],
  providers: [
    UserHttpService,
    CommonHttpService,
    DesignationHttpService,
    DepartmentHttpService,
    RoleHttpService,
    CommonValidator
  ]
})
export class UserAddModule { }
