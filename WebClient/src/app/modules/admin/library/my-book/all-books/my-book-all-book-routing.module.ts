import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyBookAllBookComponent } from './my-book-all-book.component';

const routes: Routes = [
  { path: '', component: MyBookAllBookComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyBookAllBookRoutingModule { }
