import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleRoutineAddComponent } from './batch-schedule-routine-add.component';

const routes: Routes = [
  { path: '', component: BatchScheduleRoutineAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchScheduleRoutineAddRoutingModule { }
