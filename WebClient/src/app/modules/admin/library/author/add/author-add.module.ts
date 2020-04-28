import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthorAddComponent } from './author-add.component';
import { AuthorAddRoutingModule } from './author-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';

@NgModule({
  declarations: [
    AuthorAddComponent
  ],
  imports: [
    AuthorAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AuthorAddComponent],
  providers: [
    AuthorHttpService,
    CommonValidator
  ]
})
export class AuthorAddModule { }
