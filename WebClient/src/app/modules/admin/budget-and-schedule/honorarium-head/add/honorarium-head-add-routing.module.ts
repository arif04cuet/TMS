import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HonorariumHeadAddComponent } from './honorarium-head-add.component';

const routes: Routes = [
  { path: '', component: HonorariumHeadAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HonorariumHeadAddRoutingModule { }
