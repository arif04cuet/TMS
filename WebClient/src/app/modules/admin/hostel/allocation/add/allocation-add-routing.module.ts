import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllocationAddComponent } from './allocation-add.component';

const routes: Routes = [
  { path: '', component: AllocationAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllocationAddRoutingModule { }
