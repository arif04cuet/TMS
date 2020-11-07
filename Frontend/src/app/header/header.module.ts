import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd';
import { AuthService } from 'src/services/auth.service';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/shared/share.module';

@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    NzLayoutModule,
    NzMenuModule,
    CommonModule,
    SharedModule
  ],
  exports: [HeaderComponent],
  providers: [
    AuthService
  ]
})
export class HeaderModule { }
