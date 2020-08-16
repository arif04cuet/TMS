import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SubjectListComponent } from './subject-list.component';

const routes: Routes = [
  { path: '', component: SubjectListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/subject-add.module').then(x => x.SubjectAddModule),
    data: {
      name: 'subject_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['book.category.manage', 'book.category.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/subject-add.module').then(x => x.SubjectAddModule),
    data: {
      name: 'subject_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['book.category.manage', 'book.category.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SubjectListRoutingModule { }
