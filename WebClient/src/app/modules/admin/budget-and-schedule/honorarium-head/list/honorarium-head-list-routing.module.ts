import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HonorariumHeadListComponent } from './honorarium-head-list.component';

const routes: Routes = [
  { path: '', component: HonorariumHeadListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/honorarium-head-add.module').then(x => x.HonorariumHeadAddModule),
    data: {
      name: 'honorarium_head_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['honorarium.head.manage', 'honorarium.head.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/honorarium-head-add.module').then(x => x.HonorariumHeadAddModule),
    data: {
      name: 'honorarium_head_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['honorarium.head.manage', 'honorarium.head.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HonorariumHeadListRoutingModule { }
