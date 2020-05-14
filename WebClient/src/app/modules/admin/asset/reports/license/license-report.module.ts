import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { LicenseReportComponent } from './license-report.component';
import { LicenseReportRoutingModule } from './license-report-routing.module';


@NgModule({
  declarations: [
    LicenseReportComponent
  ],
  imports: [
    CommonModule,
    LicenseReportRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LicenseReportComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class LicenseReportModule { }
