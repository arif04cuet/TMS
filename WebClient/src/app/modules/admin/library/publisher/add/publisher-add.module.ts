import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PublisherAddComponent } from './publisher-add.component';
import { PublisherAddRoutingModule } from './publisher-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';

@NgModule({
  declarations: [
    PublisherAddComponent
  ],
  imports: [
    PublisherAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [PublisherAddComponent],
  providers: [
    PublisherHttpService,
    CommonValidator
  ]
})
export class PublisherAddModule { }
