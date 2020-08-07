import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CmsFaqListComponent } from './faq-list.component';

const routes: Routes = [
  { path: '', component: CmsFaqListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/faq-add.module').then(x => x.FaqAddModule),
    data: {
      name: 'faq_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/faq-add.module').then(x => x.FaqAddModule),
    data: {
      name: 'faq_add',
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
export class FaqListRoutingModule { }
