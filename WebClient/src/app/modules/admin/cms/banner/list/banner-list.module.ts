import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BannerHttpService } from 'src/services/http/cms/banner-http.service';
import { BannerListComponent } from './banner-list.component';
import { BannerListRoutingModule } from './banner-list-routing.module';
import { SelectModule } from 'src/app/shared/select/select.module';

@NgModule({
  declarations: [
    BannerListComponent
  ],
  imports: [
    CommonModule,
    BannerListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectModule
  ],
  exports: [BannerListComponent],
  providers: [
    BannerHttpService
  ]
})
export class BannerListModule { }
