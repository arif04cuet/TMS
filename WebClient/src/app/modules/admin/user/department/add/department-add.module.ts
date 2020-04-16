import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartmentAddComponent } from './department-add.component';
import { DepartmentAddRoutingModule } from './department-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    DepartmentAddComponent
  ],
  imports: [
    DepartmentAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DepartmentAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class DepartmentAddModule { }
