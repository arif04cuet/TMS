import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepreciationScheduleReportComponent } from './depreciation-schedule-report.component';

const routes: Routes = [
  { path: '', component: DepreciationScheduleReportComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepreciationScheduleReportRoutingModule { }
