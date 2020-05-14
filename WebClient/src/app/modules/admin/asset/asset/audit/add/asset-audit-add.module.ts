import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssetAuditAddRoutingModule } from './asset-audit-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetAuditAddComponent } from './asset-audit-add.component';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { AssetAuditHttpService } from 'src/services/http/asset/asset-audit-http.service';

@NgModule({
  declarations: [
    AssetAuditAddComponent
  ],
  imports: [
    AssetAuditAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [AssetAuditAddComponent],
  providers: [
    CommonValidator,
    AssetAuditHttpService,
    AssetBaseHttpService
  ]
})
export class AssetAuditAddModule { }
