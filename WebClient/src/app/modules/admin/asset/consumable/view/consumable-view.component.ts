import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-consumable-view',
  templateUrl: './consumable-view.component.html'
})
export class ConsumableViewComponent extends BaseComponent {

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
  }

}
