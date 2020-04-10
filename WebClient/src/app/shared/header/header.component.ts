import { Component } from '@angular/core';
import { BaseComponent } from '../base.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends BaseComponent {

  constructor() {
    super();
  }

  ngOnInit() {
  }
  
}
