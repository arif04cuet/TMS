import { NgModule } from '@angular/core';

import { NzTableModule, NzAlertModule, NzFormModule, NzInputModule, NzButtonModule, NzTagModule, NzSelectModule, NzIconModule, NzListModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { AuthService } from 'src/services/auth.service';

import { SharedModule } from 'src/shared/share.module';
import { RoomFacilitiesHttpService } from 'src/services/room-facilities-http-service';
import { RoomFacilitiesComponent } from './room-facilities.component';

@NgModule({
  declarations: [
    RoomFacilitiesComponent
  ],
  exports: [RoomFacilitiesComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzTagModule,
    NzAlertModule,
    NzTableModule,
    NzSelectModule,
    NzListModule,
    NzIconModule,
    SharedModule
  ],
  providers: [
    RoomFacilitiesHttpService,
    AuthService
  ]
})
export class RoomFacilitiesModule { }
