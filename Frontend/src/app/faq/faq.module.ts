import { NgModule } from '@angular/core';
import { FaqComponent } from './faq.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    FaqComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    NzLayoutModule,
    NzCollapseModule
    
  ],
  providers:[
    
  ],
  exports: [FaqComponent]
})
export class FaqModule { }
