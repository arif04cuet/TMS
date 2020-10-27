import { NgModule } from '@angular/core';

import { BookItemListComponent } from './book-item-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookItemListRoutingModule } from './book-item-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    BookItemListComponent
  ],
  imports: [
    CommonModule,
    BookItemListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzDatePickerModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [BookItemListComponent],
  providers: [
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService
  ]
})
export class BookItemListModule { }
