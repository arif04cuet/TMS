import { NgModule } from '@angular/core';
import { FaqComponent } from './faq.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/shared/share.module';

@NgModule({
  declarations: [
    FaqComponent
  ],
  imports: [
    NzLayoutModule,
    NzCollapseModule,
    CommonModule,
    SharedModule
  ],
  providers: [

  ],
  exports: [FaqComponent]
})
export class FaqModule { }
