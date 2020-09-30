import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { IButton } from 'src/app/shared/table-actions.component';


@Component({
  selector: 'app-asset-model-list',
  templateUrl: './asset-model-list.component.html'
})
export class AssetModelListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['asset.model.manage', 'asset.model.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['asset.model.manage', 'asset.model.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private assetModelHttpService: AssetModelHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetModelHttpService);
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
      this.goTo(`/admin/asset/models/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/models/add');
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

}
