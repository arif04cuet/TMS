import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';

@Component({
  selector: 'app-consumable-details',
  templateUrl: './consumable-details.component.html'
})
export class ConsumableDetailsComponent extends BaseComponent {

  loading: boolean = true;
  item;

  constructor(
    private activatedRoute: ActivatedRoute,
    private consumableHttpService: ConsumableHttpService
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
    this.subscribe(this.consumableHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset/consumables');
  }

}
