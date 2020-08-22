import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RequisitionListComponent } from './requisition-list.component';
import { RequisitionListRoutingModule } from './requisition-list-routing.module';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';


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
    SharedModule
  ],
  exports: [RequisitionListComponent],
  providers: [
    RequisitionHttpService
  ]
})
export class RequisitionListModule { }
