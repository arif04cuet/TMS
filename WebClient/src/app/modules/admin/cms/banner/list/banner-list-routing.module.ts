import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BannerListComponent } from './banner-list.component';

const routes: Routes = [
  { path: '', component: BannerListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/banner-add.module').then(x => x.BannerAddModule),
    data: {
      name: 'banner_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['banner.manage', 'banner.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/banner-add.module').then(x => x.BannerAddModule),
    data: {
      name: 'banner_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['banner.manage', 'banner.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BannerListRoutingModule { }
