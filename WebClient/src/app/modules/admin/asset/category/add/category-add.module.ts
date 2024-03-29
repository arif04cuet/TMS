import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryAddComponent } from './category-add.component';
import { CategoryAddRoutingModule } from './category-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';

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
    SharedModule,
    PhotoUploadModule
  ],
  exports: [CategoryAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    MediaHttpService
  ]
})
export class CategoryAddModule { }
