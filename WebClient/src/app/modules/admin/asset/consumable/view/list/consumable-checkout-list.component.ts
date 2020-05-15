import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@Component({
  selector: 'app-consumable-checkout-list',
  templateUrl: './consumable-checkout-list.component.html'
})
export class ConsumableCheckoutListComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private itemCodeId;
  private itemId;

  constructor(
    private consumableHttpService: ConsumableHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(consumableHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.itemCodeId = snapshot.params.id;
    this.itemId = snapshot.params.itemId;
    this.load();
  }

  checkout() {
    this.goTo(`/admin/asset/consumables/${this.itemCodeId}/items/${this.itemId}/checkout`);
  }

  checkin(id) {
    this.goTo(`/admin/asset/consumables/${this.itemCodeId}/items/${this.itemId}checkin`);
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.consumableHttpService.listCheckouts(this.itemId, p, s);
    })
  }

}
