import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookItemReserveAddComponent } from './book-item-reserve.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { BookItemReserveAddRoutingModule } from './book-item-reserve-routing.module';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@NgModule({
  declarations: [
    BookItemReserveAddComponent
  ],
  imports: [
    BookItemReserveAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [BookItemReserveAddComponent],
  providers: [
    BookReservationHttpService,
    LibraryMemberHttpService,
    CommonValidator,
  ]
})
export class BookItemReserveAddModule { }
