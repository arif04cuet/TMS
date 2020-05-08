import { Component, Input, NgModule, ChangeDetectionStrategy } from '@angular/core';
import { SharedModule } from './shared.module';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view',
  template:  `
    <!-- <div nz-row [nzGutter]="24">
        
    </div> -->
    <nz-form-item class="field-container">
            <div>
                <label>{{label|translate}}</label>
            </div>
            <span>
                {{ data }}
            </span>
        </nz-form-item>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ViewComponent {

  @Input() label;
  @Input() data;

  constructor() {
  }

}

@NgModule({
  imports: [
    SharedModule,
    NgZorroAntdModule,
    CommonModule
  ],
  declarations: [
    ViewComponent
  ],
  exports: [
    ViewComponent
  ]
})
export class ViewModule {
  
}