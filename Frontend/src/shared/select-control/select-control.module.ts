import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SelectControlComponent } from './select-control.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    SelectControlComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SelectControlComponent]
})
export class SelectControlModule { }
