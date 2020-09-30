import { NgModule } from '@angular/core';

import { CategoryListComponent } from './category-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryListRoutingModule } from './category-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


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
    SharedModule,
    TableActionsModule
  ],
  exports: [CategoryListComponent],
  providers: [
    CategoryHttpService
  ]
})
export class CategoryListModule { }
