import { NgModule } from '@angular/core';

import { ItemCodeListComponent } from './itemcode-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ItemCodeListRoutingModule } from './itemcode-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';


@NgModule({
  declarations: [
    ItemCodeListComponent
  ],
  imports: [
    CommonModule,
    ItemCodeListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ItemCodeListComponent],
  providers: [
    ItemCodeHttpService
  ]
})
export class ItemCodeListModule { }
