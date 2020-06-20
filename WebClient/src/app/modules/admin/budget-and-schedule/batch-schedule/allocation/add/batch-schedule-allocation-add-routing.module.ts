import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleAllocationAddComponent } from './batch-schedule-allocation-add.component';

const routes: Routes = [
  { path: '', component: BatchScheduleAllocationAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchScheduleAllocationAddRoutingModule { }
