import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { DepreciationScheduleReportComponent } from './depreciation-schedule-report.component';
import { DepreciationScheduleReportRoutingModule } from './depreciation-schedule-report-routing.module';

@NgModule({
  declarations: [
    DepreciationScheduleReportComponent
  ],
  imports: [
    CommonModule,
    DepreciationScheduleReportRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DepreciationScheduleReportComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class DepreciationScheduleReportModule { }
