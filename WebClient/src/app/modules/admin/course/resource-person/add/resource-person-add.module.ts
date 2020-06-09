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
    SelectControlModule
  ],
  exports: [ResourcePersonAddComponent],
  providers: [
    CommonValidator,
    ResourcePersonHttpService,
    DesignationHttpService,
    ExpertiseHttpService
  ]
})
export class ResourcePersonAddModule { }
