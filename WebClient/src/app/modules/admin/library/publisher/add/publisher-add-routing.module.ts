import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublisherAddComponent } from './publisher-add.component';

const routes: Routes = [
  { path: '', component: PublisherAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublisherAddRoutingModule { }
