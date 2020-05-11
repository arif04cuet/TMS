import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssetDetailsComponent } from './asset-details.component';
import { AssetDetailsRoutingModule } from './asset-details-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@NgModule({
  declarations: [
    AssetDetailsComponent
  ],
  imports: [
    AssetDetailsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [AssetDetailsComponent],
  providers: [
    AssetBaseHttpService
  ]
})
export class AssetDetailsModule { }
