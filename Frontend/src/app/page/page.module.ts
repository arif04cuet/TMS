import { NgModule } from '@angular/core';
import { PageComponent } from './page.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';

@NgModule({
  declarations: [
    PageComponent
  ],
  imports: [
    NzLayoutModule
  ],
  providers:[
    
  ],
  exports: [PageComponent]
})
export class PageModule { }
