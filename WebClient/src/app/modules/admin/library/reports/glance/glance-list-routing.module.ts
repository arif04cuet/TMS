import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GlanceListComponent } from './glance-list.component';

const routes: Routes = [
  { path: '', component: GlanceListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GlanceListRoutingModule { }
