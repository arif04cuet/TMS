import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookItemIssueComponent } from './book-item-issue.component';

const routes: Routes = [
  { path: '', component: BookItemIssueComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookItemIssueRoutingModule { }
