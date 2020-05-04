import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseSeatsComponent } from './license-seats.component';

const routes: Routes = [
  { path: '', component: LicenseSeatsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseSeatsRoutingModule { }
