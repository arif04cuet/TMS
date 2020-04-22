import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemAddComponent } from './book-item-add.component';

const routes: Routes = [
  { path: '', component: BookItemAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemAddRoutingModule { }
