import { NgModule } from '@angular/core';
import { FooterComponent } from './footer.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule, NzIconModule } from 'ng-zorro-antd';
import { NzGridModule } from 'ng-zorro-antd';
import { SharedModule } from 'src/shared/share.module';

@NgModule({
  declarations: [
    FooterComponent
  ],
  imports: [
    NzLayoutModule,
    NzMenuModule,
    NzGridModule,
    NzIconModule,
    NzIconModule,
    SharedModule
  ],
  exports: [FooterComponent]
})
export class FooterModule { }
