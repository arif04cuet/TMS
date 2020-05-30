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
      }
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
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GradeListRoutingModule { }
