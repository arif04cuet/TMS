import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from 'src/app/shared/shared.module';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { PublisherListComponent } from './publisher-list.component';
import { PublisherListRoutingModule } from './publisher-list-routing.module';

@NgModule({
  declarations: [
    PublisherListComponent
  ],
  imports: [
    CommonModule,
    PublisherListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [PublisherListComponent],
  providers: [
    PublisherHttpService
  ]
})
export class PublisherListModule { }
