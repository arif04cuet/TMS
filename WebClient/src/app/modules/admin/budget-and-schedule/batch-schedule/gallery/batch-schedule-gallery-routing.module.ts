import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleGalleryComponent } from './batch-schedule-gallery.component';

const routes: Routes = [
  { path: '', component: BatchScheduleGalleryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchScheduleGalleryRoutingModule { }
