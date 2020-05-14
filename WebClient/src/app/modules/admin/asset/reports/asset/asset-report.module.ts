import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { AssetReportComponent } from './asset-report.component';
import { AssetReportRoutingModule } from './asset-report-routing.module';


@NgModule({
  declarations: [
    AssetReportComponent
  ],
  imports: [
    CommonModule,
    AssetReportRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetReportComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class AssetReportModule { }
