import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyBookEbooksComponent } from './my-book-ebooks.component';

const routes: Routes = [
  { path: '', component: MyBookEbooksComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyBookEbooksRoutingModule { }
