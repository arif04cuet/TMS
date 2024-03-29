import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoleAddComponent } from './role-add.component';
import { RoleAddRoutingModule } from './role-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { PermissionModule } from '../../permission/permission.module';

@NgModule({
  declarations: [
    RoleAddComponent
  ],
  imports: [
    RoleAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PermissionModule
  ],
  exports: [RoleAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class RoleAddModule { }
