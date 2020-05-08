import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';


@Component({
  selector: 'app-component-list',
  templateUrl: './component-list.component.html'
})
export class ComponentListComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  constructor(
    private componentHttpService: ComponentHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(componentHttpService);
  }

  ngOnInit() {
    this.statuses = this.componentHttpService.getStatus();
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/components/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/components/add');
    }
  }

  checkout(model) {
    if (model) {
      this.goTo(`/admin/asset/components/${model.id}/checkout`);
    }
  }

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/components/${model.id}/view`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

}
