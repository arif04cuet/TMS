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
import { HomePageModule } from '../homepage/homepage.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { FaqModule } from '../faq/faq.module';
import { BannerModule } from '../banner/banner.module';
import { ContentListModule } from '../content-list/content-list.module';
import { ContentListSingleModule } from '../content-list/single/content-list-single.module';

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
    LoginModule,
    HomePageModule,
    NzLayoutModule,
    FaqModule,
    BannerModule,
    ContentListModule,
    ContentListSingleModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
