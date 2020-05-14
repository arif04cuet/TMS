import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-itemcode-list',
  templateUrl: './itemcode-list.component.html',
  styleUrls: ['./itemcode-list.component.scss']
})
export class ItemCodeListComponent extends TableComponent {

  status = [];


  @Searchable("Name", "like") Name;
  @Searchable("Code", "eq") Code;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private itemcodeHttpService: ItemCodeHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(itemcodeHttpService);
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
      this.goTo(`/admin/asset/itemcodes/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/itemcodes/add');
    }
  }

  gets(pagination = null, search = null) {
    this.status = this.itemcodeHttpService.getStatus();
    this.loading = true;
    const request = [
      this.itemcodeHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
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
    this.Name = this.Code = this.IsActive = '';
  }


}
