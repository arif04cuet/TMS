import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoomTypeListRoutingModule } from './room-type-list-routing.module';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { RoomTypeListComponent } from './room-type-list.component';

@NgModule({
  declarations: [
    RoomTypeListComponent
  ],
  imports: [
    CommonModule,
    RoomTypeListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [RoomTypeListComponent],
  providers: [
    RoomTypeHttpService
  ]
})
export class RoomTypeListModule { }
