import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemCodeAddComponent } from './itemcode-add.component';

const routes: Routes = [
  { path: '', component: ItemCodeAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemCodeAddRoutingModule { }
