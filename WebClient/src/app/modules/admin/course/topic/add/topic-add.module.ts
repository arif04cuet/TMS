import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TopicAddComponent } from './topic-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { TopicAddRoutingModule } from './topic-add-routing.module';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

@NgModule({
  declarations: [
    TopicAddComponent
  ],
  imports: [
    TopicAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    CKEditorModule
  ],
  exports: [TopicAddComponent],
  providers: [
    TopicHttpService,
    CommonValidator
  ]
})
export class TopicAddModule { }
