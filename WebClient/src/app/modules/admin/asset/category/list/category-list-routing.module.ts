import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryListComponent } from './category-list.component';

const routes: Routes = [
  { path: '', component: CategoryListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/category-add.module').then(x => x.CategoryAddModule),
    data: {
      name: 'category_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/category-add.module').then(x => x.CategoryAddModule),
    data: {
      name: 'category_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryListRoutingModule { }
