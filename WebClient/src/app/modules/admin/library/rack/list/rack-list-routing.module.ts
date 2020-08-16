import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RackListComponent } from './rack-list.component';

const routes: Routes = [
  { path: '', component: RackListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/rack-add.module').then(x => x.RackAddModule),
    data: {
      name: 'rack_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['rack.manage', 'rack.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/rack-add.module').then(x => x.RackAddModule),
    data: {
      name: 'rack_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['rack.manage', 'rack.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RackListRoutingModule { }
