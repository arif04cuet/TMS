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
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { MethodHttpService } from 'src/services/http/course/method-http.service';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

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
    CKEditorModule,
    SelectControlModule
  ],
  exports: [TopicAddComponent],
  providers: [
    TopicHttpService,
    CommonValidator,
    ResourcePersonHttpService,
    MethodHttpService,
    EvaluationMethodHttpService
  ]
})
export class TopicAddModule { }
