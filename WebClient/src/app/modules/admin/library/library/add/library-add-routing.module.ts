import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LibraryAddComponent } from './library-add.component';

const routes: Routes = [
  { path: '', component: LibraryAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibraryAddRoutingModule { }
