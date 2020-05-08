import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentDetailsComponent } from './component-details.component';

const routes: Routes = [
  { path: '', component: ComponentDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentDetailsRoutingModule { }
