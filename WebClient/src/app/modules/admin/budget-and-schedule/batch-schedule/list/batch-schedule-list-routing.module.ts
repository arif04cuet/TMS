import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleListComponent } from './batch-schedule-list.component';

const routes: Routes = [
  { path: '', component: BatchScheduleListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/batch-schedule-add.module').then(x => x.BatchScheduleAddModule),
    data: {
      name: 'batch_schedule_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/batch-schedule-add.module').then(x => x.BatchScheduleAddModule),
    data: {
      name: 'batch_schedule_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchScheduleListRoutingModule { }
