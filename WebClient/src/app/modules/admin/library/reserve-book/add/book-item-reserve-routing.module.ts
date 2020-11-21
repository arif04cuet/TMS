import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemReserveAddComponent } from './book-item-reserve.component';

const routes: Routes = [
  { path: '', component: BookItemReserveAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemReserveAddRoutingModule { }
