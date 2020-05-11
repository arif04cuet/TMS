import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetCheckoutHistoryComponent } from './asset-checkout-history.component';
import { AssetCheckoutHistoryRoutingModule } from './asset-checkout-history-routing.module';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@NgModule({
  declarations: [
    AssetCheckoutHistoryComponent
  ],
  imports: [
    CommonModule,
    AssetCheckoutHistoryRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetCheckoutHistoryComponent],
  providers: [
    AssetBaseHttpService
  ]
})
export class AssetCheckoutHistoryModule { }
