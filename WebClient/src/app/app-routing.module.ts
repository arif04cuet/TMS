import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'login',
    loadChildren: () => import('./modules/public/login/login.module').then(x => x.LoginModule),
    data: {
      title: 'Login '
    }
  },
  {
    path: 'forgot-password',
    loadChildren: () => import('./modules/public/forgot-password/forgot-password.module').then(x => x.ForgotPasswordModule),
    data: {
      title: 'Forgot'
    }
  },
  {
    path: 'reset-password',
    loadChildren: () => import('./modules/public/reset-password/reset-password.module').then(x => x.ResetPasswordModule),
    data: {
      title: 'Reset Paasord '
    }
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/home/home.module').then(x => x.HomeModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    data: {
      name: 'admin',
      title: "Dashboard",
      breadcrumb: {
        icon: 'dashboard'
      }
    }
  },
  {
    path: 'access-denied',
    loadChildren: () => import('./modules/public/access-denied/access-denied.module').then(x => x.AccessDeniedModule)
  },
  {
    path: 'library/member.request',
    loadChildren: () => import('./modules/public/login/login.module').then(x => x.LoginModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
  // providers: [AdminResolver]
})
export class AppRoutingModule { }
