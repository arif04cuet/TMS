import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { FaqHttpService } from 'src/services/http/cms/faq-http.service';
import { CmsFaqListComponent } from './faq-list.component';
import { FaqListRoutingModule } from './faq-list-routing.module';

@NgModule({
  declarations: [
    CmsFaqListComponent
  ],
  imports: [
    CommonModule,
    FaqListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [CmsFaqListComponent],
  providers: [
    FaqHttpService
  ]
})
export class CmsFaqListModule { }
