import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';

@Component({
  selector: 'app-asset-details',
  templateUrl: './asset-details.component.html'
})
export class AssetDetailsComponent extends BaseComponent {

  loading: boolean = true;
  item;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetHttpService: AssetBaseHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
    const id = this.getQueryParams('id');
    this.get(id);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.assetHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset');
  }

}
