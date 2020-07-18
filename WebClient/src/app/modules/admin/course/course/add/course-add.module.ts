import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService, NzModalModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CourseAddComponent } from './course-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { CourseAddRoutingModule } from './course-add-routing.module';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ModuleModalModule } from '../module-modal/module-modal.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { CategoryHttpService } from 'src/services/http/course/category-http.service';
import { EvaluationMethodModalModule } from '../evaluation-method-modal/evaluation-method-modal.module';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { MethodHttpService } from 'src/services/http/course/method-http.service';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';

@NgModule({
  declarations: [
    CourseAddComponent
  ],
  imports: [
    CourseAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    CKEditorModule,
    ModuleModalModule,
    EvaluationMethodModalModule,
    NzModalModule,
    SelectControlModule,
    PhotoUploadModule
  ],
  exports: [CourseAddComponent],
  providers: [
    CourseHttpService,
    CommonValidator,
    NzModalService,
    CategoryHttpService,
    MethodHttpService,
    ModuleHttpService,
    MediaHttpService
  ]
})
export class CourseAddModule { }
