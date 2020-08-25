import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ViewModule } from 'src/app/shared/view.component';
import { RequisitionViewComponent } from './requisition-view.component';
import { RequisitionViewRoutingModule } from './requisition-view-routing.module';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';

@NgModule({
  declarations: [
    RequisitionViewComponent
  ],
  imports: [
    RequisitionViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ViewModule,
  ],
  exports: [RequisitionViewComponent],
  providers: [
    RequisitionHttpService
  ]
})
export class RequisitionViewModule { }
