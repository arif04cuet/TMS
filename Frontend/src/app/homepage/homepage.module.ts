import { NgModule } from '@angular/core';
import { HomePageComponent } from './homepage.component';
import { NzFormModule, NzInputModule, NzSelectModule, NzButtonModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { AuthService } from 'src/services/auth.service';
import { FaqModule } from '../faq/faq.module';
import { BannerModule } from '../banner/banner.module';
import { AboutModule } from './about/about.module';
import { CourseModule } from './courses/course.module';

@NgModule({
  declarations: [
    HomePageComponent
  ],
  exports: [HomePageComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    FaqModule,
    BannerModule,
    AboutModule,
    CourseModule
  ],
  providers: [
    AuthService
  ]
})
export class HomePageModule { }
