import { NgModule } from '@angular/core';
import { ContentListComponent } from './content-list.component';
import { NzFormModule, NzInputModule, NzSelectModule, NzButtonModule, NzTagModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { SelectModule } from 'src/shared/select/select.module';
import { CmsHttpService } from 'src/services/cms-http-service';

@NgModule({
  declarations: [
    ContentListComponent
  ],
  exports: [ContentListComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    SelectModule,
    NzTagModule
  ],
  providers: [
    CmsHttpService
  ]
})
export class ContentListModule { }
