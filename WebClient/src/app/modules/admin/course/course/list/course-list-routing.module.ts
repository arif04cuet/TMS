import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseListComponent } from './course-list.component';

const routes: Routes = [
  { path: '', component: CourseListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/course-add.module').then(x => x.CourseAddModule),
    data: {
      name: 'course_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['course.manage', 'course.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/course-add.module').then(x => x.CourseAddModule),
    data: {
      name: 'course_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['course.manage', 'course.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseListRoutingModule { }
