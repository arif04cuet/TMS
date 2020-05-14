import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepreciationReportComponent } from './depreciation-report.component';

const routes: Routes = [
  { path: '', component: DepreciationReportComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepreciationReportRoutingModule { }
