import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentCheckinComponent } from './component-checkin.component';

const routes: Routes = [
  { path: '', component: ComponentCheckinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentCheckinRoutingModule { }
