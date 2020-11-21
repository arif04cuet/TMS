import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemReserveListComponent } from './book-item-reserve-list.component';

const routes: Routes = [
  { path: '', component: BookItemReserveListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/book-item-reserve.module').then(x => x.BookItemReserveAddModule),
    data: {
      name: 'book_reservation_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['book.reservation.manage', 'book.reservation.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/book-item-reserve.module').then(x => x.BookItemReserveAddModule),
    data: {
      name: 'book_reservation_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['book.reservation.manage', 'book.reservation.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemReserveListRoutingModule { }
