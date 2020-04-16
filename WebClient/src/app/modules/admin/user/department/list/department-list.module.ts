import { NgModule } from '@angular/core';

import { DepartmentListComponent } from './department-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartmentListRoutingModule } from './department-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DepartmentHttpService } from 'src/services/http/department-http.service';

@NgModule({
  declarations: [
    DepartmentListComponent
  ],
  imports: [
    CommonModule,
    DepartmentListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DepartmentListComponent],
  providers: [
    DepartmentHttpService
  ]
})
export class DepartmentListModule { }
