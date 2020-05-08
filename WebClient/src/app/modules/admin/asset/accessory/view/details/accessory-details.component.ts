import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';

@Component({
  selector: 'app-accessory-details',
  templateUrl: './accessory-details.component.html'
})
export class AccessoryDetailsComponent extends BaseComponent {

  loading: boolean = true;
  item;

  constructor(
    private activatedRoute: ActivatedRoute,
    private accessoryHttpService: AccessoryHttpService
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
    this.subscribe(this.accessoryHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset/accessories');
  }

}
