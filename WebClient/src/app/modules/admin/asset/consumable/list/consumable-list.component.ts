import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@Component({
  selector: 'app-consumable-list',
  templateUrl: './consumable-list.component.html'
})
export class ConsumableListComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  constructor(
    private consumableHttpService: ConsumableHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(consumableHttpService);
  }

  ngOnInit() {
    this.statuses = this.consumableHttpService.getStatus();
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
    }
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

}
