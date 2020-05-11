import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@Component({
  selector: 'app-asset-component-list',
  templateUrl: './asset-component-list.component.html'
})
export class AssetComponentListComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private id;

  constructor(
    private assetHttpService: AssetBaseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.id = this._activatedRouteSnapshot.params.id;
    this.load();
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.assetHttpService.getComponents(this.id, p, s);
    })
  }

}
