import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { AssetAuditLogComponent } from './asset-audit-log.component';
import { AssetAuditLogRoutingModule } from './asset-audit-log-routing.module';


@NgModule({
  declarations: [
    AssetAuditLogComponent
  ],
  imports: [
    CommonModule,
    AssetAuditLogRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetAuditLogComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class AssetAuditLogModule { }
