import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { SelectModule } from 'src/app/shared/select/select.module';
import { BatchCheckoutModalComponent } from './batch-checkout-modal.component';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    BatchCheckoutModalComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    SelectModule
  ],
  exports: [BatchCheckoutModalComponent],
  providers: [
    AllocationHttpService,
    NzModalService,
    CommonValidator
  ]
})
export class BatchCheckoutModalModule { }
