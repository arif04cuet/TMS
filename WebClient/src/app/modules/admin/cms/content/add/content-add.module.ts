import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContentAddComponent } from './content-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { ContentAddRoutingModule } from './content-add-routing.module';
import { ContentHttpService } from 'src/services/http/cms/content-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

@NgModule({
  declarations: [
    ContentAddComponent
  ],
  imports: [
    ContentAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PhotoUploadModule,
    SelectControlModule,
    CKEditorModule
  ],
  exports: [ContentAddComponent],
  providers: [
    ContentHttpService,
    CommonValidator
  ]
})
export class ContentAddModule { }
