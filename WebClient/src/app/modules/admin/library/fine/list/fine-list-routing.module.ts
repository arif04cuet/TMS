import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FineListComponent } from './fine-list.component';

const routes: Routes = [
  { path: '', component: FineListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FineListRoutingModule { }
