import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileAddComponent } from './profile-add.component';
import { UserHttpService } from 'src/services/http/user-http.service';
import { ProfileAddRoutingModule } from './profile-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/designation-http.service';
import { DepartmentHttpService } from 'src/services/http/department-http.service';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    ProfileAddComponent
  ],
  imports: [
    ProfileAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ProfileAddComponent],
  providers: [
    UserHttpService,
    CommonHttpService,
    DesignationHttpService,
    DepartmentHttpService,
    RoleHttpService,
    CommonValidator
  ]
})
export class ProfileAddModule { }
