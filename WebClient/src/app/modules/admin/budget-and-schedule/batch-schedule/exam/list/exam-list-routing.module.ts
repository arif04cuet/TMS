import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamListComponent } from './exam-list.component';

const routes: Routes = [
  { path: '', component: ExamListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/exam-add.module').then(x => x.ExamAddModule),
    data: {
      name: 'exam_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/exam-add.module').then(x => x.ExamAddModule),
    data: {
      name: 'exam_add',
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
export class ExamListRoutingModule { }
