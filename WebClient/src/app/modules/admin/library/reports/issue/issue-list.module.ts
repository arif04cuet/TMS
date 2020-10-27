import { NgModule } from '@angular/core';

import { IssueListComponent } from './issue-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IssueListRoutingModule } from './issue-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';

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
    LibraryReportHttpService,
    AuthorHttpService,
    LibraryMemberHttpService
  ]
})
export class IssueListModule { }
