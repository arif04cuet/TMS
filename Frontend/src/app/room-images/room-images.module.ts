import { NgModule } from '@angular/core';
import { RoomImagesComponent } from './room-images.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCarouselModule } from 'ng-zorro-antd/carousel';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/shared/share.module';
import { RoomHttpService } from 'src/services/room-http.service';

@NgModule({
  declarations: [
    RoomImagesComponent
  ],
  imports: [
    CommonModule,
    NzLayoutModule,
    NzCarouselModule,
    SharedModule
  ],
  providers: [
    RoomHttpService
  ],
  exports: [RoomImagesComponent]
})
export class RoomImagesModule { }
