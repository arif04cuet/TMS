import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RackAddComponent } from './rack-add.component';
import { RackAddRoutingModule } from './rack-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@NgModule({
  declarations: [
    RackAddComponent
  ],
  imports: [
    RackAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [RackAddComponent],
  providers: [
    RackHttpService,
    CommonValidator,
    LibraryHttpService
  ]
})
export class RackAddModule { }
