import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModuleAddComponent } from './module-add.component';

const routes: Routes = [
  { path: '', component: ModuleAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModuleAddRoutingModule { }
