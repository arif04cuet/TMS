import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService, NzModalModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModuleAddComponent } from './module-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { ModuleAddRoutingModule } from './module-add-routing.module';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { TopicsModalModule } from '../topics-modal/topics-modal.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { UserHttpService } from 'src/services/http/user/user-http.service';

@NgModule({
  declarations: [
    ModuleAddComponent
  ],
  imports: [
    ModuleAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    CKEditorModule,
    TopicsModalModule,
    NzModalModule,
    SelectControlModule
  ],
  exports: [ModuleAddComponent],
  providers: [
    ModuleHttpService,
    CommonValidator,
    NzModalService,
    UserHttpService
  ]
})
export class ModuleAddModule { }
