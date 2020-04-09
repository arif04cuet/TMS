import { Component, Input, NgModule } from '@angular/core';
import { NzIconModule } from 'ng-zorro-antd';

@Component({
    selector: 'app-box-loader',
    template:  `
    <div class="box box-loader">
        <div class="block pad-v-12 pad-h-20 border-radius-5 box-loader-inner">
            <i nz-icon nzType="loading" style="font-size: 24px;"></i> 
        </div>
    </div>
    `
  })
  export class BoxLoaderComponent {
  
    @Input() loading: boolean = false;
    @Input() noData: boolean = false;
  
    constructor() {
    }
  
  }

  @NgModule({
    declarations: [
      BoxLoaderComponent
    ],
    exports: [
      BoxLoaderComponent
    ],
    imports: [
      NzIconModule
    ]
  })
  export class BoxLoaderModule {

  }