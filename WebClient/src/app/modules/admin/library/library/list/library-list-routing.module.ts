import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LibraryListComponent } from './library-list.component';

const routes: Routes = [
  { path: '', component: LibraryListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/library-add.module').then(x => x.LibraryAddModule),
    data: {
      name: 'user_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/library-add.module').then(x => x.LibraryAddModule),
    data: {
      name: 'user_add',
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
export class LibraryListRoutingModule { }
