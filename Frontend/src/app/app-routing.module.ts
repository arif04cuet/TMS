import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LibraryMemberRegistrationComponent } from './library-member-registration/library-member-registration.component';
import { TrainingCourseComponent } from './training-course/training-course.component';
import { TrainingCourseViewComponent } from './training-course/view/training-course-view.component';
import { TrainingCourseApplyComponent } from './training-course/apply/training-course-apply.component';
import { LoginComponent } from './login/login.component';
import { HomePageComponent } from './homepage/homepage.component';
import { PageComponent } from './page/page.component';
import { FaqComponent } from './faq/faq.component';
import { ContentListComponent } from './content-list/content-list.component';
import { ContentListSingleComponent } from './content-list/single/content-list-single.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  {
    path: '',
    // loadChildren: () => import('./home/home.module').then(x => x.HomeModule)
    component: HomeComponent,
    children: [
      {
        path: '',
        component: HomePageComponent
      },
      {
        path: 'contents/:category',
        component: ContentListComponent
      },
      {
        path: 'contents/:category/:id',
        component: ContentListSingleComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'faq',
        component: FaqComponent
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
        path: 'page/:slug',
        component: PageComponent
      },
      {
        path: 'course/:id/apply',
        component: TrainingCourseApplyComponent
      },
      {
        path: 'registration',
        component: RegistrationComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
