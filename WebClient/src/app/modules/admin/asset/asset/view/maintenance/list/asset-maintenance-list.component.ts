import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetMaintenanceHttpService } from 'src/services/http/asset/asset-maintenance-http.service';
import { IButton } from 'src/app/shared/table-actions.component';


@Component({
  selector: 'app-asset-maintenance-list',
  templateUrl: './asset-maintenance-list.component.html'
})
export class AssetMaintenanceListComponent extends TableComponent {

  @Searchable("Asset.AssetTag", "like") assetName;

  id;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      icon: 'delete'
    }
  ]

  constructor(
    private assetMaintenanceHttpService: AssetMaintenanceHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetMaintenanceHttpService);
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
        return this.assetMaintenanceHttpService.list(this.id, p, s);
      }
      else {
        return this.assetMaintenanceHttpService.listAll(p, s);
      }
    })
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/maintenances/${model.id}/edit`);
    }
    else {
      let url = `/admin/asset/maintenances/add`;
      if (this.id) {
        url += `?assetId=${this.id}`
      }
      this.goTo(url);
    }
  }

}
