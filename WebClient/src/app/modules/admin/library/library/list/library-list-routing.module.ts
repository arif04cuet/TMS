import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LibraryListComponent } from './library-list.component';

const routes: Routes = [
  { path: '', component: LibraryListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/library-add.module').then(x => x.LibraryAddModule),
    data: {
      name: 'library_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['library.manage', 'library.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/library-add.module').then(x => x.LibraryAddModule),
    data: {
      name: 'library_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['library.manage', 'library.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibraryListRoutingModule { }
