import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { SelectModule } from 'src/app/shared/select/select.module';
import { RoomModalComponent } from './room-modal.component';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';

@NgModule({
  declarations: [
    RoomModalComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    SelectModule
  ],
  exports: [RoomModalComponent],
  providers: [
    RoomHttpService,
    HostelHttpService,
    NzModalService,
    RoomTypeHttpService
  ]
})
export class RoomModalModule { }
