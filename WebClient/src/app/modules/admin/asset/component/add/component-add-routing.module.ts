import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentAddComponent } from './component-add.component';

const routes: Routes = [
  { path: '', component: ComponentAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentAddRoutingModule { }
