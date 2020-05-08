import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryDetailsComponent } from './accessory-details.component';

const routes: Routes = [
  { path: '', component: AccessoryDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryDetailsRoutingModule { }
