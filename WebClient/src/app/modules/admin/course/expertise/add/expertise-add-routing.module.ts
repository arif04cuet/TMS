import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExpertiseAddComponent } from './expertise-add.component';

const routes: Routes = [
  { path: '', component: ExpertiseAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExpertiseAddRoutingModule { }
