import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemListComponent } from './book-item-list.component';

const routes: Routes = [
  { path: '', component: BookItemListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../edit/book-item-edit.module').then(x => x.BookItemEditModule),
    data: {
      name: 'book_item_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['book.manage', 'book.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/book-item-add.module').then(x => x.BookItemAddModule),
    data: {
      name: 'book_item_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['book.manage', 'book.create']
    }
  },
  {
    path: ':id/issues',
    loadChildren: () => import('../issue/book-item-issue.module').then(x => x.BookItemIssueModule),
    data: {
      name: 'book_item_issue',
      breadcrumb: {
        icon: 'plus',
        title: 'issue'
      },
      permissions: ['book.manage', 'book.issue']
    }
  },
  {
    path: 'issues',
    loadChildren: () => import('../issue/book-item-issue.module').then(x => x.BookItemIssueModule),
    data: {
      name: 'book_item_issue',
      breadcrumb: {
        icon: 'plus',
        title: 'issue'
      },
      permissions: ['book.manage', 'book.issue']
    }
  },
  {
    path: ':id/returns',
    loadChildren: () => import('../return/book-item-return.module').then(x => x.BookItemReturnModule),
    data: {
      name: 'book_item_return',
      breadcrumb: {
        icon: 'plus',
        title: 'return'
      },
      permissions: ['book.manage', 'book.return']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemListRoutingModule { }
