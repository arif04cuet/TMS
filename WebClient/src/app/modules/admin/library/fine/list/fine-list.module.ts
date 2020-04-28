import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { FineListComponent } from './fine-list.component';
import { FineListRoutingModule } from './fine-list-routing.module';

@NgModule({
  declarations: [
    FineListComponent
  ],
  imports: [
    CommonModule,
    FineListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [FineListComponent],
  providers: [
    BookHttpService,
    AuthorHttpService,
    LibraryMemberHttpService
  ]
})
export class FineListModule { }
