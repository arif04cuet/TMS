import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookAddComponent } from './book-add.component';
import { UserHttpService } from 'src/services/http/user-http.service';
import { BookAddRoutingModule } from './book-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { AuthorHttpService } from 'src/services/http/author-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';

@NgModule({
  declarations: [
    BookAddComponent
  ],
  imports: [
    BookAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BookAddComponent],
  providers: [
    UserHttpService,
    BookHttpService,
    CommonValidator,
    CommonHttpService,
    AuthorHttpService,
    PublisherHttpService
  ]
})
export class BookAddModule { }
