import { NgModule } from '@angular/core';

import { CardListComponent } from './card-list.component';
import { CommonModule, DatePipe } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardListRoutingModule } from './card-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@NgModule({
  declarations: [
    CardListComponent
  ],
  imports: [
    CommonModule,
    CardListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [CardListComponent],
  providers: [
    LibraryCardHttpService,
    DatePipe
  ]
})
export class CardListModule { }
