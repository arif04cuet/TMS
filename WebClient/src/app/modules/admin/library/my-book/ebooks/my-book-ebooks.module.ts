import { NgModule } from '@angular/core';

import { MyBookEbooksComponent } from './my-book-ebooks.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyBookEbooksRoutingModule } from './my-book-ebooks-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    MyBookEbooksComponent
  ],
  imports: [
    CommonModule,
    MyBookEbooksRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzDatePickerModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [MyBookEbooksComponent],
  providers: [
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService
  ]
})
export class MyBookEbooksModule { }
