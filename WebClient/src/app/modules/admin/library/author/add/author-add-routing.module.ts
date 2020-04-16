import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorAddComponent } from './author-add.component';

const routes: Routes = [
  { path: '', component: AuthorAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorAddRoutingModule { }
