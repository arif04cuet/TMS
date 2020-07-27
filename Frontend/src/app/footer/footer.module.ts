import { NgModule } from '@angular/core';
import { FooterComponent } from './footer.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [
    FooterComponent
  ],
  imports: [
    NzLayoutModule,
    NzMenuModule
  ],
  exports: [FooterComponent]
})
export class FooterModule { }
