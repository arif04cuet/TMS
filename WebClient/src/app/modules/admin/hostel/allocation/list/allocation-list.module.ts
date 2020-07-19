import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AllocationListComponent } from './allocation-list.component';
import { AllocationListRoutingModule } from './allocation-list-routing.module';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { BatchCheckoutModalModule } from '../batch-checkout-modal/batch-checkout-modal.module';

@NgModule({
  declarations: [
    AllocationListComponent
  ],
  imports: [
    CommonModule,
    AllocationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    BatchCheckoutModalModule
  ],
  exports: [AllocationListComponent],
  providers: [
    AllocationHttpService
  ]
})
export class AllocationListModule { }
