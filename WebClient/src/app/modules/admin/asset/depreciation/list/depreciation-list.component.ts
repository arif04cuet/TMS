import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { DepreciationHttpService } from 'src/services/http/asset/depreciation-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-depreciation-list',
  templateUrl: './depreciation-list.component.html'
})
export class DepreciationListComponent extends TableComponent {

  statuses = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("Name", "like") Name;
  @Searchable("Term", "eq") Term;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private depreciationHttpService: DepreciationHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(depreciationHttpService);
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
      this.goTo(`/admin/asset/depreciations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/depreciations/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.depreciationHttpService.list(pagination, search)
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
    this.Name = this.Term = this.IsActive = '';
  }

}
