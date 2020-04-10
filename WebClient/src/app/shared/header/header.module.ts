import { NgModule } from '@angular/core';

import { HeaderComponent } from './header.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [HeaderComponent]
})
export class HeaderModule { }
