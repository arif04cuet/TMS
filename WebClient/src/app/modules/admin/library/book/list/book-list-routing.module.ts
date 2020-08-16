import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListComponent } from './book-list.component';

const routes: Routes = [
  { path: '', component: BookListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/book-add.module').then(x => x.BookAddModule),
    data: {
      name: 'book_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['book.catalog.manage', 'book.catalog.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/book-add.module').then(x => x.BookAddModule),
    data: {
      name: 'book_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['book.catalog.manage', 'book.catalog.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookListRoutingModule { }
