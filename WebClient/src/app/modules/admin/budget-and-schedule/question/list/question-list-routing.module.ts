import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuestionListComponent } from './question-list.component';

const routes: Routes = [
  { path: '', component: QuestionListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/question-add.module').then(x => x.QuestionAddModule),
    data: {
      name: 'question_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['question.manage', 'question.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/question-add.module').then(x => x.QuestionAddModule),
    data: {
      name: 'question_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['question.manage', 'question.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionListRoutingModule { }
