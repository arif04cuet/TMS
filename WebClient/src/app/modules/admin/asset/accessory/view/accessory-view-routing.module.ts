import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryViewComponent } from './accessory-view.component';

const routes: Routes = [
  { path: '', component: AccessoryViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryViewRoutingModule { }
