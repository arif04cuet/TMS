import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MethodAddComponent } from './method-add.component';
import { CommonValidator } from 'src/validators/common.validator';
import { MethodAddRoutingModule } from './method-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { MethodHttpService } from 'src/services/http/course/method-http.service';

@NgModule({
  declarations: [
    MethodAddComponent
  ],
  imports: [
    MethodAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MethodAddComponent],
  providers: [
    MethodHttpService,
    CommonValidator
  ]
})
export class MethodAddModule { }
