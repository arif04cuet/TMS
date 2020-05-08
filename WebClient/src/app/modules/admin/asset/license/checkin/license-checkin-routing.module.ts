import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseCheckinComponent } from './license-checkin.component';

const routes: Routes = [
  { path: '', component: LicenseCheckinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseCheckinRoutingModule { }
