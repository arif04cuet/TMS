import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@Component({
  selector: 'app-consumable-list',
  templateUrl: './consumable-list.component.html'
})
export class ConsumableListComponent extends TableComponent {

  private itemCodeId;

  constructor(
    private consumableHttpService: ConsumableHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(consumableHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.itemCodeId = snapshot.params.id;
    this.snapshot(snapshot);
    this.load();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/consumables/add');
    }
  }

  checkout(model) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${model.id}/checkout`);
    }
  }

  item(model = null) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${model.id}/items`);
    }
  }

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/consumables/${model.id}/view`);
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
      return this.consumableHttpService.listGroupByItemCode(p, s);
    });
  }

}
