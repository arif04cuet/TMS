import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TopicAddComponent } from './topic-add.component';

const routes: Routes = [
  { path: '', component: TopicAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TopicAddRoutingModule { }
