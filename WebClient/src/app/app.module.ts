import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgZorroAntdModule, NZ_I18N, NZ_ICONS, en_US } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { SecurityService } from 'src/services/security.service';
import { HttpService } from 'src/services/http/http.service';
import { ErrorInterceptor } from 'src/interceptors/error.interceptor';
import { BroadcastService } from 'src/services/broadcast.service';
import { IdentityService } from 'src/services/identity.service';
import { AuthService } from 'src/services/auth.service';
import { IconDefinition } from '@ant-design/icons-angular';
import * as AllIcons from '@ant-design/icons-angular/icons'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { environment } from 'src/environments/environment';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import {TranslateModule, TranslateLoader, TranslatePipe, TranslateService} from '@ngx-translate/core';
import { AuthGuard } from 'src/guards/auth.guard';
import { PermissionHttpService } from 'src/services/http/user/permission-http.service';
import { MediaHttpService } from 'src/services/http/media-http.service';

registerLocaleData(en);

const antDesignIcons = AllIcons as {
  [key: string]: IconDefinition;
};
const icons: IconDefinition[] = Object.keys(antDesignIcons).map(key => antDesignIcons[key])

// AoT requires an exported function for factories
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, environment.langFilePath);
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    IconsProviderModule,
    BrowserAnimationsModule,
    NgZorroAntdModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
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
    { provide: NZ_ICONS, useValue: icons },
    SecurityService,
    HttpService,
    AuthService,
    IdentityService,
    BroadcastService,
    PermissionHttpService,
    MediaHttpService,
    TranslatePipe,
    { provide: ErrorHandler, useClass: ErrorHandler },
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
