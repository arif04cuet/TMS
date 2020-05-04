import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseDetailsComponent } from './license-details.component';

const routes: Routes = [
  { path: '', component: LicenseDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseDetailsRoutingModule { }
