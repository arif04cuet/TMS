import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';


@Component({
  selector: 'app-consumable-items',
  templateUrl: './consumable-items.component.html'
})
export class ConsumableItemsComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  itemCode;
  title;
  private itemCodeId;

  constructor(
    private consumableHttpService: ConsumableHttpService,
    private activatedRoute: ActivatedRoute,
    private itemCodeHttpService: ItemCodeHttpService
  ) {
    super(consumableHttpService);
  }

  ngOnInit() {
    this.statuses = this.consumableHttpService.getStatus();
    const snapshot = this.activatedRoute.snapshot;
    this.itemCodeId = snapshot.params.id;
    this.snapshot(snapshot);
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
    }
    this.getData();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${model.id}/edit`);
    }
    else {
      this.goTo(`/admin/asset/consumables/add?itemCodeId=${this.itemCodeId}`);
    }
  }

  checkout(model) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${this.itemCodeId}/items/${model.id}/checkout`);
    }
  }

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${this.itemCodeId}/items/${model.id}/view`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.consumableHttpService.listByItemCode(this.itemCodeId, p, s);
    });
  }

  getData() {
    this.subscribe(this.itemCodeHttpService.get(this.itemCodeId),
      (res: any) => {
        this.itemCode = res.data;
        this.title = `${this.itemCode.code} - ${this.itemCode.name} - ${this.itemCode.category.name}`
      },
      err => { }
    );
  }

}
