import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GradeListComponent } from './grade-list.component';

const routes: Routes = [
  { path: '', component: GradeListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/grade-add.module').then(x => x.GradeAddModule),
    data: {
      name: 'grade_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['grade.manage', 'grade.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/grade-add.module').then(x => x.GradeAddModule),
    data: {
      name: 'grade_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['grade.manage', 'grade.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GradeListRoutingModule { }
