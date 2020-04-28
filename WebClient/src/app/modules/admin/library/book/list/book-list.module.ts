import { NgModule } from '@angular/core';

import { BookListComponent } from './book-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookListRoutingModule } from './book-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';

@NgModule({
  declarations: [
    BookListComponent
  ],
  imports: [
    CommonModule,
    BookListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BookListComponent],
  providers: [
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService
  ]
})
export class BookListModule { }
