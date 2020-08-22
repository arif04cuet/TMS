import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RequisitionAddComponent } from './requisition-add.component';

const routes: Routes = [
  { path: '', component: RequisitionAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequisitionAddRoutingModule { }
