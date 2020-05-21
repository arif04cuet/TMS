import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ViewModule } from 'src/app/shared/view.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { AssetBulkCheckoutComponent } from './asset-bulk-checkout.component';
import { AssetBulkCheckoutRoutingModule } from './asset-bulk-checkout-routing.module';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    AssetBulkCheckoutComponent
  ],
  imports: [
    AssetBulkCheckoutRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [AssetBulkCheckoutComponent],
  providers: [
    AssetBaseHttpService,
    UserHttpService,
    OfficeHttpService,
    CommonValidator
  ]
})
export class AssetBulkCheckoutModule { }
