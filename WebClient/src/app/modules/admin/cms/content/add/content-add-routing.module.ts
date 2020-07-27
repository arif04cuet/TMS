import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentAddComponent } from './content-add.component';

const routes: Routes = [
  { path: '', component: ContentAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentAddRoutingModule { }
