import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoomTypeAddComponent } from './room-type-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { RoomTypeAddRoutingModule } from './room-type-add-routing.module';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    RoomTypeAddComponent
  ],
  imports: [
    RoomTypeAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [RoomTypeAddComponent],
  providers: [
    RoomTypeHttpService,
    DesignationHttpService,
    CommonValidator
  ]
})
export class RoomTypeAddModule { }
