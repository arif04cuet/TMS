import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BannerAddComponent } from './banner-add.component';

const routes: Routes = [
    { path: '', component: BannerAddComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BannerAddRoutingModule { }
