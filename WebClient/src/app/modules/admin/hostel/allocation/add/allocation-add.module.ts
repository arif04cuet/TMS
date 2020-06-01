import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService, NzModalModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllocationAddComponent } from './allocation-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { AllocationAddRoutingModule } from './allocation-add-routing.module';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BedModalModule } from '../bed-modal/bed-modal.module';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { RoomModalModule } from '../room-modal/room-modal.module';
import { ViewModule } from 'src/app/shared/view.component';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';

@NgModule({
  declarations: [
    AllocationAddComponent
  ],
  imports: [
    AllocationAddRoutingModule,
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
  exports: [AllocationAddComponent],
  providers: [
    BuildingHttpService,
    HostelHttpService,
    AllocationHttpService,
    CommonValidator,
    UserHttpService,
    BedHttpService,
    RoomHttpService,
    NzModalService
  ]
})
export class AllocationAddModule { }
