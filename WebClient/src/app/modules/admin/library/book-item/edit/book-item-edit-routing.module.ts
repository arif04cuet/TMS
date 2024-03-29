import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemEditComponent } from './book-item-edit.component';

const routes: Routes = [
  { path: '', component: BookItemEditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemEditRoutingModule { }
