import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MethodListComponent } from './method-list.component';

const routes: Routes = [
  { path: '', component: MethodListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/method-add.module').then(x => x.MethodAddModule),
    data: {
      name: 'method_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['method.manage', 'method.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/method-add.module').then(x => x.MethodAddModule),
    data: {
      name: 'method_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['method.manage', 'method.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MethodListRoutingModule { }
