import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookItemAddComponent } from './book-item-add.component';
import { BookItemAddRoutingModule } from './book-item-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    BookItemAddComponent
  ],
  imports: [
    BookItemAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [BookItemAddComponent],
  providers: [
    BookHttpService,
    CommonValidator,
    RackHttpService,
    LibraryHttpService
  ]
})
export class BookItemAddModule { }
