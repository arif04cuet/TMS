import { NgModule } from '@angular/core';
import { HotelAndRoomComponent } from './hotel-and-room.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { CommonModule } from '@angular/common';
import { HotelHttpService } from 'src/services/hotel-http-service';
import { NzButtonModule, NzDatePickerModule, NzTableModule, NzGridModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    HotelAndRoomComponent
  ],
  imports: [
    CommonModule,
    NzLayoutModule,
    NzCollapseModule,
    CommonModule,
    NzButtonModule,
    NzDatePickerModule,
    NzTableModule,
    FormsModule,
    NzGridModule,
    NzSelectModule
  ],
  providers:[
    HotelHttpService
  ],
  exports: [HotelAndRoomComponent]
})
export class HotelAndRoomModule { }
