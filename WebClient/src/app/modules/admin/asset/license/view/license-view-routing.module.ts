import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseViewComponent } from './license-view.component';

const routes: Routes = [
  { path: '', component: LicenseViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseViewRoutingModule { }
