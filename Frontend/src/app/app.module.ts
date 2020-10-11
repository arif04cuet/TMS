import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
import { HotelHttpService } from 'src/services/hotel-http-service';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { NZ_I18N, en_US } from 'ng-zorro-antd';
import { environment } from 'src/environments/environment';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule, TranslatePipe } from '@ngx-translate/core';

registerLocaleData(en);

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, environment.langFilePath);
}

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
    HomeModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    HttpService,
    NzMessageService,
    NzModalService,
    AuthService,
    SecurityService,
    CmsHttpService,
    RegistrationHttpService,
    CommonValidator,
    HotelHttpService,
    TranslatePipe,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
