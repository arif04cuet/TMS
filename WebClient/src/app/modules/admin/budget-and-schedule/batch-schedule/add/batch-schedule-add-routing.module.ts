import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleAddComponent } from './batch-schedule-add.component';

const routes: Routes = [
  { path: '', component: BatchScheduleAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchScheduleAddRoutingModule { }
