import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzFormModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { SelectComponent } from './select.component';
import { SharedModule } from '../share.module';

@NgModule({
  declarations: [
    SelectComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    NzSelectModule,
    SharedModule
  ],
  exports: [SelectComponent]
})
export class SelectModule { }
