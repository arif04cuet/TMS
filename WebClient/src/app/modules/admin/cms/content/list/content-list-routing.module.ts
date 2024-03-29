import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CmsContentListComponent } from './content-list.component';

const routes: Routes = [
  { path: '', component: CmsContentListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/content-add.module').then(x => x.ContentAddModule),
    data: {
      name: 'content_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['content.manage', 'content.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/content-add.module').then(x => x.ContentAddModule),
    data: {
      name: 'content_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['content.manage', 'content.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentListRoutingModule { }
