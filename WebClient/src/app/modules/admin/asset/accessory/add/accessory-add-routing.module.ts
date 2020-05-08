import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryAddComponent } from './accessory-add.component';

const routes: Routes = [
  { path: '', component: AccessoryAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryAddRoutingModule { }
