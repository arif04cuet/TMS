import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TopicListComponent } from './topic-list.component';

const routes: Routes = [
  { path: '', component: TopicListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/topic-add.module').then(x => x.TopicAddModule),
    data: {
      name: 'topic_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/topic-add.module').then(x => x.TopicAddModule),
    data: {
      name: 'topic_add',
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
export class TopicListRoutingModule { }
