import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';
import { CmsCategoryListComponent } from './category-list.component';
import { CategoryListRoutingModule } from './category-list-routing.module';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    CmsCategoryListComponent
  ],
  imports: [
    CommonModule,
    CategoryListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [CmsCategoryListComponent],
  providers: [
    CategoryHttpService,
    CommonValidator
  ]
})
export class CmsCategoryListModule { }
