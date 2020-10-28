import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LostListComponent } from './lost-list.component';

const routes: Routes = [
  { path: '', component: LostListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LostListRoutingModule { }
