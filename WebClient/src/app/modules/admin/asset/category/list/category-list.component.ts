import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  mastercategories = [];


  @Searchable("Name", "like") Name;
  @Searchable("Type", "eq") Type;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private categoryHttpService: CategoryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(categoryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/categories/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/categories/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.categoryHttpService.list(pagination, search),
      this.categoryHttpService.mastercategories()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.mastercategories = res[1].data.items;
        console.log(res);
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );

  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

  refresh() {
    this.resetFilters();
    this.gets(null, null);
  }

  resetFilters() {
    this.Name = this.Type = this.IsActive = '';
  }

  getTypeName(typeId) {

    return this.mastercategories.find(x => x.id === typeId);

  }

}
