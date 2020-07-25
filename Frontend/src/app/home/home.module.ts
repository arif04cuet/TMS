import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { HeaderModule } from '../header/header.module';
import { FooterModule } from '../footer/footer.module';
import { RouterModule } from '@angular/router';
import { LibraryMemberRegistrationModule } from '../library-member-registration/library-member-registration.module';
import { TrainingCourseModule } from '../training-course/training-course.module';
import { TrainingCourseViewModule } from '../training-course/view/training-course-view.module';
import { TrainingCourseApplyModule } from '../training-course/apply/training-course-apply.module';
import { LoginModule } from '../login/login.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    RouterModule,
    HeaderModule,
    FooterModule,
    LibraryMemberRegistrationModule,
    TrainingCourseModule,
    TrainingCourseViewModule,
    TrainingCourseApplyModule,
    LoginModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
