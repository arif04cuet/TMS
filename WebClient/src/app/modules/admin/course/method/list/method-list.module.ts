import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MethodHttpService } from 'src/services/http/course/method-http.service';
import { MethodListComponent } from './method-list.component';
import { MethodListRoutingModule } from '../../method/list/method-list-routing.module';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    MethodListComponent
  ],
  imports: [
    CommonModule,
    MethodListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MethodListComponent],
  providers: [
    MethodHttpService,
    CommonValidator
  ]
})
export class MethodListModule { }
