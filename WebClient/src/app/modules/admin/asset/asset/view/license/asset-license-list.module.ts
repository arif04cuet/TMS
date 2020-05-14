import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { AssetLicenseListRoutingModule } from './asset-license-list-routing.module';
import { AssetLicenseListComponent } from './asset-license-list.component';


@NgModule({
  declarations: [
    AssetLicenseListComponent
  ],
  imports: [
    CommonModule,
    AssetLicenseListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetLicenseListComponent],
  providers: [
    UserHttpService,
    AssetBaseHttpService
  ]
})
export class AssetLicenseListModule { }
