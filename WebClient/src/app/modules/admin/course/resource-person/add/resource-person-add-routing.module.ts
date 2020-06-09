import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourcePersonAddComponent } from './resource-person-add.component';

const routes: Routes = [
  { path: '', component: ResourcePersonAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourcePersonAddRoutingModule { }
