import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RequisitionListComponent } from './requisition-list.component';
import { RequisitionListRoutingModule } from './requisition-list-routing.module';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    RequisitionListComponent
  ],
  imports: [
    CommonModule,
    RequisitionListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    NzSelectModule,
    TableActionsModule
  ],
  exports: [RequisitionListComponent],
  providers: [
    RequisitionHttpService
  ]
})
export class RequisitionListModule { }
