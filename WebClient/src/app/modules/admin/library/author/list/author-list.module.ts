import { NgModule } from '@angular/core';

import { AuthorListComponent } from './author-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthorListRoutingModule } from './author-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthorHttpService } from 'src/services/http/author-http.service';

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
    AuthorHttpService
  ]
})
export class AuthorListModule { }
