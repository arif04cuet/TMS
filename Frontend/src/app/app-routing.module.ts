import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LibraryMemberRegistrationComponent } from './library-member-registration/library-member-registration.component';
import { TrainingCourseComponent } from './training-course/training-course.component';
import { TrainingCourseViewComponent } from './training-course/view/training-course-view.component';
import { TrainingCourseApplyComponent } from './training-course/apply/training-course-apply.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {
    path: '',
    // loadChildren: () => import('./home/home.module').then(x => x.HomeModule)
    component: HomeComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'member-registration',
        component: LibraryMemberRegistrationComponent
      },
      {
        path: 'course',
        component: TrainingCourseComponent
      },
      {
        path: 'course/:id',
        component: TrainingCourseViewComponent
      },
      {
        path: 'course/:id/apply',
        component: TrainingCourseApplyComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
