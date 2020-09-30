import { NgModule } from '@angular/core';

import { LicenseListComponent } from './license-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseListRoutingModule } from './license-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    LicenseListComponent
  ],
  imports: [
    CommonModule,
    LicenseListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [LicenseListComponent],
  providers: [
    LicenseHttpService,
    UserHttpService,
    AssetBaseHttpService
  ]
})
export class LicenseListModule { }
