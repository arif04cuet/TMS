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
      }
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
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseListRoutingModule { }
