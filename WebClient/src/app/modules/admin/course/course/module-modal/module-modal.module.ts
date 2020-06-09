import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ModuleModalComponent } from './module-modal.component';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';

@NgModule({
  declarations: [
    ModuleModalComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ModuleModalComponent],
  providers: [
    ModuleHttpService,
    NzModalService
  ]
})
export class ModuleModalModule { }
