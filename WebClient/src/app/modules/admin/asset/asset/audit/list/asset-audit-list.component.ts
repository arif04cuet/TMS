import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetAuditHttpService } from 'src/services/http/asset/asset-audit-http.service';


@Component({
  selector: 'app-asset-audit-list',
  templateUrl: './asset-audit-list.component.html'
})
export class AssetAuditListComponent extends TableComponent {

  @Searchable("Name", "like") Name;
  id;

  constructor(
    private assetAuditHttpService: AssetAuditHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetAuditHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.id = Number(this._activatedRouteSnapshot.params.id);
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
      if (this.id) {
        return this.assetAuditHttpService.list(this.id, p, s);
      }
      else {
        return this.assetAuditHttpService.listAll(p, s);
      }
    })
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/audit/${this.id}/edit`);
    }
    else {
      let url = `/admin/asset/audit/add`;
      if(this.id) {
        url += `?assetId=${this.id}`
      }
      this.goTo(url);
    }
  }

}
