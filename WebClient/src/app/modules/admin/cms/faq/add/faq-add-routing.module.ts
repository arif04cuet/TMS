import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FaqAddComponent } from './faq-add.component';

const routes: Routes = [
  { path: '', component: FaqAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FaqAddRoutingModule { }
