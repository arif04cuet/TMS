import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExpertiseListComponent } from './expertise-list.component';

const routes: Routes = [
  { path: '', component: ExpertiseListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/expertise-add.module').then(x => x.ExpertiseAddModule),
    data: {
      name: 'expertise_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/expertise-add.module').then(x => x.ExpertiseAddModule),
    data: {
      name: 'expertise_add',
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
export class ExpertiseListRoutingModule { }
