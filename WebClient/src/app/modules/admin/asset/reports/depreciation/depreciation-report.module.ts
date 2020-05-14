import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { DepreciationReportComponent } from './depreciation-report.component';
import { DepreciationReportRoutingModule } from './depreciation-report-routing.module';


@NgModule({
  declarations: [
    DepreciationReportComponent
  ],
  imports: [
    CommonModule,
    DepreciationReportRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DepreciationReportComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class DepreciationReportModule { }
