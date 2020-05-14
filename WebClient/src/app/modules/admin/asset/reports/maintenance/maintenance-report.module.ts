import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';
import { MaintenanceReportComponent } from './maintenance-report.component';
import { MaintenanceReportRoutingModule } from './maintenance-report-routing.module';


@NgModule({
  declarations: [
    MaintenanceReportComponent
  ],
  imports: [
    CommonModule,
    MaintenanceReportRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MaintenanceReportComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class MaintenanceReportModule { }
