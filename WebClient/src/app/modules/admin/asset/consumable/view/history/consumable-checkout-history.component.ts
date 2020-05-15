import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@Component({
  selector: 'app-consumable-checkout-history',
  templateUrl: './consumable-checkout-history.component.html'
})
export class ConsumableCheckoutHistoryComponent extends TableComponent {

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

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.consumableHttpService.listCheckoutHistory(this.itemId, p, s);
    })
  }

}
