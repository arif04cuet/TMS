import { NgModule } from '@angular/core';

import { MyBookAllBookComponent } from './my-book-all-book.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyBookAllBookRoutingModule } from './my-book-all-book-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';


@NgModule({
  declarations: [
    MyBookAllBookComponent
  ],
  imports: [
    CommonModule,
    MyBookAllBookRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzDatePickerModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [MyBookAllBookComponent],
  providers: [
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService,
    BookReservationHttpService
  ]
})
export class MyBookAllBookModule { }
