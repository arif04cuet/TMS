import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CardListComponent } from './card-list.component';

const routes: Routes = [
  { path: '', component: CardListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/card-add.module').then(x => x.CardAddModule),
    data: {
      name: 'library_card_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['card.manage', 'card.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/card-add.module').then(x => x.CardAddModule),
    data: {
      name: 'library_card_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['card.manage', 'card.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CardListRoutingModule { }
