import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-asset-view',
  templateUrl: './asset-view.component.html'
})
export class AssetViewComponent extends BaseComponent {

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
  }

  back_to_list() {

    this.goTo('/admin/asset');

  }

}
