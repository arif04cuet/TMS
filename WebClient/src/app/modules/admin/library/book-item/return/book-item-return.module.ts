import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { BookItemReturnComponent } from './book-item-return.component';
import { BookItemReturnRoutingModule } from './book-item-return-routing.module';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    BookItemReturnComponent
  ],
  imports: [
    BookItemReturnRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ViewModule
  ],
  exports: [BookItemReturnComponent],
  providers: [
    BookHttpService,
    CommonValidator,
    CommonHttpService,
    LibraryMemberHttpService
  ]
})
export class BookItemReturnModule { }
