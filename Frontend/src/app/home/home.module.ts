import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { HeaderModule } from '../header/header.module';
import { FooterModule } from '../footer/footer.module';
import { RouterModule } from '@angular/router';
import { LibraryMemberRegistrationModule } from '../library-member-registration/library-member-registration.module';
import { TrainingCourseModule } from '../training-course/training-course.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    RouterModule,
    HeaderModule,
    FooterModule,
    LibraryMemberRegistrationModule,
    TrainingCourseModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
