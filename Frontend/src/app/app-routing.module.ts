import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LibraryMemberRegistrationComponent } from './library-member-registration/library-member-registration.component';
import { TrainingCourseComponent } from './training-course/training-course.component';

const routes: Routes = [
  {
    path: '',
    // loadChildren: () => import('./home/home.module').then(x => x.HomeModule)
    component: HomeComponent,
    children: [
      {
        path: 'member-registration',
        component: LibraryMemberRegistrationComponent
      },
      {
        path: 'course',
        component: TrainingCourseComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }