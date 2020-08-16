import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublisherListComponent } from './publisher-list.component';

const routes: Routes = [
  { path: '', component: PublisherListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/publisher-add.module').then(x => x.PublisherAddModule),
    data: {
      name: 'publisher_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['publisher.manage', 'publisher.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/publisher-add.module').then(x => x.PublisherAddModule),
    data: {
      name: 'publisher_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['publisher.manage', 'publisher.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublisherListRoutingModule { }
