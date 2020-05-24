import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html'
})
export class AssetListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("AssetTag", "like") assetTag;
  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  serverUrl = environment.serverUri;

  constructor(
    private assetHttpService: AssetBaseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.load();

    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/add');
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  view(model) {
    if(model) {
      this.goTo(`/admin/asset/${model.id}/view`);
    }
  }

  checkout(model) {
    if(model) {
      this.goTo(`/admin/asset/${model.id}/checkout`);
    }
  }

  checkin(model) {
    if(model) {
      this.goTo(`/admin/asset/${model.id}/checkin`);
    }
  }

}
