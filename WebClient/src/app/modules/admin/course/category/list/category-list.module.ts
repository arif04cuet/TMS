import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CategoryHttpService } from 'src/services/http/course/category-http.service';
import { CategoryListComponent } from './category-list.component';
import { CategoryListRoutingModule } from './category-list-routing.module';

@NgModule({
  declarations: [
    CategoryListComponent
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
  exports: [CategoryListComponent],
  providers: [
    CategoryHttpService
  ]
})
export class CategoryListModule { }
