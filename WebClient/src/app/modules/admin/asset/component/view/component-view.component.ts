import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-component-view',
  templateUrl: './component-view.component.html'
})
export class ComponentViewComponent extends BaseComponent {

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
  }

}
