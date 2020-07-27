import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CmsCategoryListComponent } from './category-list.component';

const routes: Routes = [
  { path: '', component: CmsCategoryListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/category-add.module').then(x => x.CategoryAddModule),
    data: {
      name: 'category_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
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
        title: 'add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryListRoutingModule { }
