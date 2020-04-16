import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorListComponent } from './author-list.component';

const routes: Routes = [
  { path: '', component: AuthorListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/author-add.module').then(x => x.AuthorAddModule),
    data: {
      name: 'author_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/author-add.module').then(x => x.AuthorAddModule),
    data: {
      name: 'author_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorListRoutingModule { }
