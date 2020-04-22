import { NgModule } from '@angular/core';

import { BookItemListComponent } from './book-item-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user-http.service';
import { BookItemListRoutingModule } from './book-item-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/author-http.service';

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
    SharedModule
  ],
  exports: [BookItemListComponent],
  providers: [
    UserHttpService,
    BookHttpService,
    PublisherHttpService,
    AuthorHttpService
  ]
})
export class BookItemListModule { }