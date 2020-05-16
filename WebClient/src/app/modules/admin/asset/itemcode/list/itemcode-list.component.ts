import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-itemcode-list',
  templateUrl: './itemcode-list.component.html'
})
export class ItemCodeListComponent extends TableComponent {

  status = [];

  @Searchable("Name", "like") Name;
  @Searchable("Code", "eq") Code;
  @Searchable("IsActive", "eq") IsActive;

  private parentId;

  constructor(
    private itemcodeHttpService: ItemCodeHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(itemcodeHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.parentId = snapshot.data.parentId;
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    let item = '';
    if (this.parentId == 2) {
      item = 'consumable';
    }
    else if (this.parentId == 3) {
      item = 'license';
    }
    if (model) {
      this.goTo(`/admin/asset/itemcodes/${item}/${model.id}/edit`);
    }
    else {
      this.goTo(`/admin/asset/itemcodes/${item}/add`);
    }
  }

  gets(pagination = null, search = null) {
    this.status = this.itemcodeHttpService.getStatus();
    this.loading = true;
    let request = this.itemcodeHttpService.list(pagination, search);
    if (this.parentId) {
      request = this.itemcodeHttpService.listByCategory(this.parentId, pagination, search);
    }
    this.subscribe(request,
      (res: any) => {
        this.fill(res);
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
    this.resetFilters();
    this.gets(null, null);
  }

  resetFilters() {
    this.Name = this.Code = this.IsActive = '';
  }


}
