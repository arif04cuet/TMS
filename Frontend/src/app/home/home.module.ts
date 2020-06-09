import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { HeaderModule } from '../header/header.module';
import { FooterModule } from '../footer/footer.module';
import { RouterModule } from '@angular/router';
import { LibraryMemberRegistrationModule } from '../library-member-registration/library-member-registration.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    RouterModule,
    HeaderModule,
    FooterModule,
    LibraryMemberRegistrationModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
