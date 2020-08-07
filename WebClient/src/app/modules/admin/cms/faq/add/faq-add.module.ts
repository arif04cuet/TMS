import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FaqAddComponent } from './faq-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { FaqAddRoutingModule } from './faq-add-routing.module';
import { FaqHttpService } from 'src/services/http/cms/faq-http.service';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

@NgModule({
  declarations: [
    FaqAddComponent
  ],
  imports: [
    FaqAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    CKEditorModule
  ],
  exports: [FaqAddComponent],
  providers: [
    FaqHttpService,
    CommonValidator
  ]
})
export class FaqAddModule { }
