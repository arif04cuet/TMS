import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { ResourcePersonAddComponent } from './resource-person-add.component';
import { ResourcePersonAddRoutingModule } from './resource-person-add-routing.module';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';


@NgModule({
  declarations: [
    ResourcePersonAddComponent
  ],
  imports: [
    ResourcePersonAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    PhotoUploadModule
  ],
  exports: [ResourcePersonAddComponent],
  providers: [
    CommonValidator,
    ResourcePersonHttpService,
    DesignationHttpService,
    ExpertiseHttpService,
    HonorariumHeadHttpService,
    MediaHttpService,
    UserHttpService
  ]
})
export class ResourcePersonAddModule { }
