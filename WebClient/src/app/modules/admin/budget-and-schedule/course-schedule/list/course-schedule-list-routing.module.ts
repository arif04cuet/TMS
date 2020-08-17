import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseScheduleListComponent } from './course-schedule-list.component';

const routes: Routes = [
  { path: '', component: CourseScheduleListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/course-schedule-add.module').then(x => x.CourseScheduleAddModule),
    data: {
      name: 'course_schedule_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['schedule.manage', 'schedule.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/course-schedule-add.module').then(x => x.CourseScheduleAddModule),
    data: {
      name: 'course_schedule_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['schedule.manage', 'schedule.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseScheduleListRoutingModule { }
