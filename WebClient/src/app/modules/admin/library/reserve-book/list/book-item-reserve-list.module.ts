import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { TableActionsModule } from 'src/app/shared/table-actions.component';
import { BookItemReserveListComponent } from './book-item-reserve-list.component';
import { BookItemReserveListRoutingModule } from './book-item-reserve-list-routing.module';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';


@NgModule({
  declarations: [
    BookItemReserveListComponent
  ],
  imports: [
    CommonModule,
    BookItemReserveListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzDatePickerModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [BookItemReserveListComponent],
  providers: [
    BookReservationHttpService,
  ]
})
export class BookItemReserveListModule { }
