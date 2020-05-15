import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { ConsumableItemsComponent } from './consumable-items.component';
import { ConsumableItemsRoutingModule } from './consumable-items-routing.module';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';


@NgModule({
  declarations: [
    ConsumableItemsComponent
  ],
  imports: [
    CommonModule,
    ConsumableItemsRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ConsumableItemsComponent],
  providers: [
    ConsumableHttpService,
    ItemCodeHttpService
  ]
})
export class ConsumableItemsModule { }
