import { NgModule } from '@angular/core';
import { BannerComponent } from './banner.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd';
import { NzCarouselModule } from 'ng-zorro-antd/carousel';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    BannerComponent
  ],
  imports: [
    CommonModule,
    NzLayoutModule,
    NzCarouselModule
  ],
  providers:[
    
  ],
  exports: [BannerComponent]
})
export class BannerModule { }
