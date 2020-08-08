import { NgModule } from '@angular/core';
import { AboutComponent } from './about.component';
import { NzGridModule, NzTabsModule, NzButtonModule, NzIconModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { ContentListModule } from 'src/app/content-list/content-list.module';



@NgModule({
  declarations: [
    AboutComponent
  ],
  exports: [AboutComponent],
  imports: [
    CommonModule,
    NzGridModule,
    NzTabsModule,
    ContentListModule,
    NzIconModule
  ],
  providers: []
})
export class AboutModule { }
