import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'login',
    loadChildren: () => import('./modules/public/login/login.module').then(x => x.LoginModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/home/home.module').then(x => x.HomeModule),
    canActivate: [AuthGuard],
    data: {
      name: 'admin',
      breadcrumb: {
        icon: 'dashboard'
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
