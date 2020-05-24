import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoomAddComponent } from './room-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { RoomAddRoutingModule } from './room-add-routing.module';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';

@NgModule({
  declarations: [
    RoomAddComponent
  ],
  imports: [
    RoomAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [RoomAddComponent],
  providers: [
    RoomHttpService,
    RoomTypeHttpService,
    BuildingHttpService,
    HostelHttpService,
    FacilitiesHttpService,
    CommonValidator
  ]
})
export class RoomAddModule { }
