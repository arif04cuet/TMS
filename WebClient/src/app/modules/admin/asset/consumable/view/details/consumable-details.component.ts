import { Component } from '@angular/core';
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

  private itemCodeId;
  private itemId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private consumableHttpService: ConsumableHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
    this.itemCodeId = this._activatedRouteSnapshot.params.id;
    this.itemId = this._activatedRouteSnapshot.params.itemId;
    this.get(this.itemId);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.consumableHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.item.item = `${this.item.itemCode.code} - ${this.item.itemCode.name}`;
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset/consumables');
  }

}
