import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModuleListComponent } from './module-list.component';

const routes: Routes = [
  { path: '', component: ModuleListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/course-add.module').then(x => x.ModuleAddModule),
    data: {
      name: 'module_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/course-add.module').then(x => x.ModuleAddModule),
    data: {
      name: 'module_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModuleListRoutingModule { }
