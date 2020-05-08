import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';


@Component({
  selector: 'app-accessory-list',
  templateUrl: './accessory-list.component.html'
})
export class AccessoryListComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  constructor(
    private accessoryHttpService: AccessoryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(accessoryHttpService);
  }

  ngOnInit() {
    this.statuses = this.accessoryHttpService.getStatus();
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/accessories/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/accessories/add');
    }
  }

  checkout(model) {
    if (model) {
      this.goTo(`/admin/asset/accessories/${model.id}/checkout`);
    }
  }

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/accessories/${model.id}/view`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

}
