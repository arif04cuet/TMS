import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemReturnComponent } from './book-item-return.component';

const routes: Routes = [
  { path: '', component: BookItemReturnComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemReturnRoutingModule { }
