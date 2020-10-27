import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewListComponent } from './new-list.component';

const routes: Routes = [
  { path: '', component: NewListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewListRoutingModule { }
