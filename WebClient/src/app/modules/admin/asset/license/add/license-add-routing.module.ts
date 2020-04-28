import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseAddComponent } from './license-add.component';

const routes: Routes = [
  { path: '', component: LicenseAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseAddRoutingModule { }
