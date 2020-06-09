import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ModuleListComponent } from './module-list.component';
import { ModuleListRoutingModule } from './module-list-routing.module';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';

@NgModule({
  declarations: [
    ModuleListComponent
  ],
  imports: [
    CommonModule,
    ModuleListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ModuleListComponent],
  providers: [
    ModuleHttpService
  ]
})
export class ModuleListModule { }
