import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { PhotoUploadModule } from 'src/app/shared/photo.component';
import { ViewModule } from 'src/app/shared/view.component';
import { RequisitionAddComponent } from './requisition-add.component';
import { RequisitionAddRoutingModule } from './requisition-add-routing.module';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AssetModalModule } from '../asset-modal/asset-modal.module';

@NgModule({
  declarations: [
    RequisitionAddComponent
  ],
  imports: [
    RequisitionAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    PhotoUploadModule,
    ViewModule,
    NzModalModule,
    AssetModalModule
  ],
  exports: [RequisitionAddComponent],
  providers: [
    CommonValidator,
    RequisitionHttpService,
    BatchScheduleHttpService,
    UserHttpService,
    NzModalService
  ]
})
export class RequisitionAddModule { }
