import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-status-list',
  templateUrl: './status-list.component.html'
})
export class StatusListComponent extends TableComponent {

  statuses = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  masterstatuses = [];

  @Searchable("Name", "like") Name;
  @Searchable("Type", "eq") Type;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private statusHttpService: StatusHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(statusHttpService);
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
      this.goTo(`/admin/asset/statuses/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/statuses/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.statusHttpService.list(pagination, search),
      this.statusHttpService.masterstatuses()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.masterstatuses = res[1].data.items;
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
    return this.masterstatuses.find(x => x.id === typeId);
  }

}
