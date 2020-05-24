import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoomListComponent } from './room-list.component';
import { RoomListRoutingModule } from './room-list-routing.module';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';

@NgModule({
  declarations: [
    RoomListComponent
  ],
  imports: [
    CommonModule,
    RoomListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [RoomListComponent],
  providers: [
    RoomHttpService
  ]
})
export class RoomListModule { }
