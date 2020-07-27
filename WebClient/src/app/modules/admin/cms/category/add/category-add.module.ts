import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryAddComponent } from './category-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { CategoryAddRoutingModule } from './category-add-routing.module';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';

@NgModule({
  declarations: [
    CategoryAddComponent
  ],
  imports: [
    CategoryAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [CategoryAddComponent],
  providers: [
    CategoryHttpService,
    CommonValidator
  ]
})
export class CategoryAddModule { }
