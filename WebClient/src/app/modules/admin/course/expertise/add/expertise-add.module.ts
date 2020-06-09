import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { ExpertiseAddComponent } from './expertise-add.component';
import { ExpertiseAddRoutingModule } from './expertise-add-routing.module';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';

@NgModule({
  declarations: [
    ExpertiseAddComponent
  ],
  imports: [
    ExpertiseAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ExpertiseAddComponent],
  providers: [
    ExpertiseHttpService,
    CommonValidator
  ]
})
export class ExpertiseAddModule { }
