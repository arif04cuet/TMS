import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';


@Component({
  selector: 'app-asset-model-list',
  templateUrl: './asset-model-list.component.html',
  styleUrls: ['./asset-model-list.component.scss']
})
export class AssetModelListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("Name", "like") Name;
  @Searchable("Type", "eq") Type;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private assetModelHttpService: AssetModelHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetModelHttpService);
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
      this.goTo(`/admin/asset/models/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/models/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.assetModelHttpService.list(pagination, search)
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
    this.Name = this.Type = this.IsActive = '';
  }

}
