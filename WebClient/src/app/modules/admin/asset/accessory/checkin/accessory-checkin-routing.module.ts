import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryCheckinComponent } from './accessory-checkin.component';

const routes: Routes = [
  { path: '', component: AccessoryCheckinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryCheckinRoutingModule { }
