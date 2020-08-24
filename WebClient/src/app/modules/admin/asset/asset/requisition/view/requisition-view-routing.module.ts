import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RequisitionViewComponent } from './requisition-view.component';

const routes: Routes = [
  { path: '', component: RequisitionViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequisitionViewRoutingModule { }
