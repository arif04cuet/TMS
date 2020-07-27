import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyExamListComponent } from './my-exam-list.component';

const routes: Routes = [
  { path: '', component: MyExamListComponent },
  {
    path: ':id/view',
    loadChildren: () => import('./view/my-exam-view.module').then(x => x.MyExamViewModule),
    data: {
      name: 'my_exam_view',
      breadcrumb: {
        icon: 'edit',
        title: 'my.exam'
      }
    }
  },
  {
    path: ':id/start',
    loadChildren: () => import('./start/my-exam-start.module').then(x => x.MyExamStartModule),
    data: {
      name: 'my_exam_start',
      breadcrumb: {
        icon: 'edit',
        title: 'my.exam'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyExamListRoutingModule { }
