import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';

@Component({
  selector: 'app-cms-category-list',
  templateUrl: './category-list.component.html'
})
export class CmsCategoryListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private categoryHttpService: CategoryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(categoryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/cms/categories/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/cms/categories/add');
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }


}
