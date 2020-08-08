import { NgModule } from '@angular/core';
import { HotelAndRoomComponent } from './hotel-and-room.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    HotelAndRoomComponent
  ],
  imports: [
    NzLayoutModule,
    NzCollapseModule,
    CommonModule
  ],
  providers:[
    
  ],
  exports: [HotelAndRoomComponent]
})
export class HotelAndRoomModule { }
