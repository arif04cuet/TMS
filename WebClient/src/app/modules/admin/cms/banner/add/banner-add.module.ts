import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BannerAddComponent } from './banner-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BannerAddRoutingModule } from './banner-add-routing.module';
import { BannerHttpService } from 'src/services/http/cms/banner-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';


@NgModule({
  declarations: [
    BannerAddComponent
  ],
  imports: [
    BannerAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PhotoUploadModule,
    SelectControlModule
  ],
  exports: [BannerAddComponent],
  providers: [
    BannerHttpService,
    CommonValidator
  ]
})
export class BannerAddModule { }
