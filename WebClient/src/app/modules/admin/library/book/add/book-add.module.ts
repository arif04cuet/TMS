import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookAddComponent } from './book-add.component';
import { BookAddRoutingModule } from './book-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { SubjectHttpService } from 'src/services/http/subject-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';

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
    SharedModule,
    PhotoUploadModule
  ],
  exports: [BookAddComponent],
  providers: [
    BookHttpService,
    CommonValidator,
    CommonHttpService,
    AuthorHttpService,
    PublisherHttpService,
    SubjectHttpService
  ]
})
export class BookAddModule { }
