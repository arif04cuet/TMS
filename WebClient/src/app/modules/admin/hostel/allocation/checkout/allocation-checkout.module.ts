import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService, NzModalModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BedModalModule } from '../bed-modal/bed-modal.module';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { RoomModalModule } from '../room-modal/room-modal.module';
import { ViewModule } from 'src/app/shared/view.component';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { AllocationCheckoutComponent } from './allocation-checkout.component';
import { AllocationCheckoutRoutingModule } from './allocation-checkout-routing.module';

@NgModule({
  declarations: [
    AllocationCheckoutComponent
  ],
  imports: [
    AllocationCheckoutRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    NzModalModule,
    BedModalModule,
    RoomModalModule,
    ViewModule
  ],
  exports: [AllocationCheckoutComponent],
  providers: [
    BuildingHttpService,
    AllocationHttpService,
    CommonValidator,
    UserHttpService,
    BedHttpService,
    RoomHttpService,
    NzModalService
  ]
})
export class AllocationCheckoutModule { }
