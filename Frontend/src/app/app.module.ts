import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeModule } from './home/home.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpService } from 'src/services/http.service';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { AuthService } from 'src/services/auth.service';
import { SecurityService } from 'src/services/security.service';
import {CmsHttpService} from 'src/services/cms-http-service';
import { RegistrationHttpService } from 'src/services/registration-http-service';
import { CommonValidator } from 'src/shared/common.validator';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HomeModule
  ],
  providers: [
    HttpService,
    NzMessageService,
    NzModalService,
    AuthService,
    SecurityService,
    CmsHttpService,
    RegistrationHttpService,
    CommonValidator
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
