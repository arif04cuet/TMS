import { Component, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
    selector: 'app-form-section-title',
    template:  `
    <div nz-row [nzGutter]="24">
    <div nz-col [nzSpan]="24" style="margin: 10px 0">
        <span class="title-text">
            {{'x0.information'|translate:{x0: title}|uppercase}}
        </span>
    </div>
    </div>
    `,
    changeDetection: ChangeDetectionStrategy.OnPush
  })
  export class FormSectionTitleComponent {

    @Input() title;
  
    constructor() {
    }
  
  }