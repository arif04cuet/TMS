import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyBookListComponent } from './my-book-list.component';

const routes: Routes = [
  { path: '', component: MyBookListComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyBookListRoutingModule { }
