import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EvaluationMethodListComponent } from './evaluation-method-list.component';

const routes: Routes = [
  { path: '', component: EvaluationMethodListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/evaluation-method-add.module').then(x => x.EvaluationMethodAddModule),
    data: {
      name: 'evaluation_method_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/evaluation-method-add.module').then(x => x.EvaluationMethodAddModule),
    data: {
      name: 'evaluation_method_add',
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
export class EvaluationMethodListRoutingModule { }
