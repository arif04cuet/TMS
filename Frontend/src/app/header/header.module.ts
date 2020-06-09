import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    NzLayoutModule,
    NzMenuModule
  ],
  exports: [HeaderComponent]
})
export class HeaderModule { }
