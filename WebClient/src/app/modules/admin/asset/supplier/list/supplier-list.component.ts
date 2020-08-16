import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { SupplierHttpService } from 'src/services/http/asset/supplier-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html'
})
export class SupplierListComponent extends TableComponent {

  statuses = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("Name", "like") Name;
  @Searchable("ContactName", "like") ContactName;
  @Searchable("ContactEmail", "like") ContactEmail;
  @Searchable("ContactPhone", "like") ContactPhone;
  @Searchable("IsActive", "eq") IsActive;

  constructor(
    private supplierHttpService: SupplierHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(supplierHttpService);
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
      this.goTo(`/admin/asset/suppliers/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/suppliers/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.supplierHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
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
    this.Name = this.ContactName = this.ContactEmail = this.IsActive = this.ContactPhone = '';
  }

}
