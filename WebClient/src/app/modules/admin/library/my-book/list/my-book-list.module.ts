import { NgModule } from '@angular/core';

import { MyBookListComponent } from './my-book-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyBookListRoutingModule } from './my-book-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    MyBookListComponent
  ],
  imports: [
    CommonModule,
    MyBookListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzDatePickerModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [MyBookListComponent],
  providers: [
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService
  ]
})
export class MyBookListModule { }
