import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourcePersonListComponent } from './resource-person-list.component';

const routes: Routes = [
  { path: '', component: ResourcePersonListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/resource-person-add.module').then(x => x.ResourcePersonAddModule),
    data: {
      name: 'resource_person_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['resource.person.manage', 'resource.person.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/resource-person-add.module').then(x => x.ResourcePersonAddModule),
    data: {
      name: 'resource_person_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['resource.person.manage', 'resource.person.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourcePersonRoutingModule { }
