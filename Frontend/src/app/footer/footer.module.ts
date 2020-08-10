import { NgModule } from '@angular/core';
import { FooterComponent } from './footer.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule, NzIconModule } from 'ng-zorro-antd';
import { NzGridModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [
    FooterComponent
  ],
  imports: [
    NzLayoutModule,
    NzMenuModule,
    NzGridModule,
    NzIconModule,
    NzIconModule
  ],
  exports: [FooterComponent]
})
export class FooterModule { }
