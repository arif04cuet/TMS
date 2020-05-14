import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@Component({
  selector: 'app-asset-license-list',
  templateUrl: './asset-license-list.component.html'
})
export class AssetLicenseListComponent extends TableComponent {

  @Searchable("Name", "like") Name;
  @Searchable("ProductKey", "like") ProductKey;
  @Searchable("IsActive", "eq") IsActive;

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
    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  checkin(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/checkin`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.assetHttpService.getLicenses(this.id, p, s);
    })
  }

}
