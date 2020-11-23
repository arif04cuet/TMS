import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { IButton } from 'src/app/shared/table-actions.component';


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html'
})
export class CategoryListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  nonEditable = [];

  @Searchable("Name", "like") Name;
  @Searchable("Parent.Name", "like") Parent;
  @Searchable("IsActive", "eq") IsActive;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['asset.category.manage', 'asset.category.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['asset.category.manage', 'asset.category.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private categoryHttpService: CategoryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(categoryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
    this.nonEditable = this.categoryHttpService.masterCategories();
    console.log(this.nonEditable);
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
      this.categoryHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
      },
      err => {
        this.loading = false;
      }
    );

  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

  refresh() {
    this.gets(null, null);
  }

  isEditable(category) {

    return !this.nonEditable.includes(category.name.trim());
  }

}
