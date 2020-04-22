import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookItemEditRoutingModule } from './book-item-edit-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BookHttpService } from 'src/services/http/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { BookItemEditComponent } from './book-item-edit.component';

@NgModule({
  declarations: [
    BookItemEditComponent
  ],
  imports: [
    BookItemEditRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BookItemEditComponent],
  providers: [
    BookHttpService,
    CommonValidator,
    CommonHttpService,
    RackHttpService
  ]
})
export class BookItemEditModule { }
