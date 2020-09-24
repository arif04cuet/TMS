import { NgModule } from '@angular/core';

import { AuthorListComponent } from './author-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthorListRoutingModule } from './author-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    AuthorListComponent
  ],
  imports: [
    CommonModule,
    AuthorListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AuthorListComponent],
  providers: [
    AuthorHttpService,
    CommonValidator
  ]
})
export class AuthorListModule { }
