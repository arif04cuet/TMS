import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentViewComponent } from './component-view.component';

const routes: Routes = [
  { path: '', component: ComponentViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentViewRoutingModule { }
