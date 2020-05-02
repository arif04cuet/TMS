import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookItemIssueRoutingModule } from './book-item-issue-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { BookItemIssueComponent } from './book-item-issue.component';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@NgModule({
  declarations: [
    BookItemIssueComponent
  ],
  imports: [
    BookItemIssueRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BookItemIssueComponent],
  providers: [
    BookHttpService,
    CommonValidator,
    LibraryMemberHttpService
  ]
})
export class BookItemIssueModule { }
