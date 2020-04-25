import { NgModule } from '@angular/core';

import { IssueListComponent } from './issue-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IssueListRoutingModule } from './issue-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/book-http.service';
import { AuthorHttpService } from 'src/services/http/author-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@NgModule({
  declarations: [
    IssueListComponent
  ],
  imports: [
    CommonModule,
    IssueListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [IssueListComponent],
  providers: [
    BookHttpService,
    AuthorHttpService,
    LibraryMemberHttpService
  ]
})
export class IssueListModule { }
