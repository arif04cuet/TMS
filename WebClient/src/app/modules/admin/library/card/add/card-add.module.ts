import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardAddComponent } from './card-add.component';
import { CardAddRoutingModule } from './card-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    CardAddComponent
  ],
  imports: [
    CardAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [CardAddComponent],
  providers: [
    LibraryCardHttpService,
    CommonValidator
  ]
})
export class CardAddModule { }
