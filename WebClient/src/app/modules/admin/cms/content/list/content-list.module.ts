import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ContentHttpService } from 'src/services/http/cms/content-http.service';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';
import { CmsContentListComponent } from './content-list.component';
import { ContentListRoutingModule } from './content-list-routing.module';
import { SelectModule } from 'src/app/shared/select/select.module';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    CmsContentListComponent
  ],
  imports: [
    CommonModule,
    ContentListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectModule,
    TableActionsModule
  ],
  exports: [CmsContentListComponent],
  providers: [
    ContentHttpService,
    CategoryHttpService
  ]
})
export class CmsContentListModule { }
