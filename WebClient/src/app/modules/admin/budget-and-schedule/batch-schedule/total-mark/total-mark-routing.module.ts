import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TotalMarkComponent } from './total-mark.component';

const routes: Routes = [
  { path: '', component: TotalMarkComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TotalMarkRoutingModule { }
