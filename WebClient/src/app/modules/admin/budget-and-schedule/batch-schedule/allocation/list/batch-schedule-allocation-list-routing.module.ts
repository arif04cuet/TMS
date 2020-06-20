import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BatchScheduleAllocationListComponent } from './batch-schedule-allocation-list.component';

const routes: Routes = [
  { path: '', component: BatchScheduleAllocationListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/batch-schedule-allocation-add.module').then(x => x.BatchScheduleAllocationAddModule),
    data: {
      name: 'batch_schedule_allocation_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/batch-schedule-allocation-add.module').then(x => x.BatchScheduleAllocationAddModule),
    data: {
      name: 'batch_schedule_allocation_add',
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
export class BatchScheduleAllocationListRoutingModule { }
