import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { environment } from 'src/environments/environment';
import { IButton } from 'src/app/shared/table-actions.component';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { forkJoin } from 'rxjs';


@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html'
})
export class AssetListComponent extends TableComponent {

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  categories = [];

  @Searchable("AssetTag", "like") assetTag;
  @Searchable("Name", "like") name;
  @Searchable("AssetModel.Name", "like") assetModel;
  @Searchable("AssetModel.CategoryId", "eq") categoryId;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'asset.checkout',
      action: d => this.checkout(d),
      condition: d => !d.checkoutId,
      type: 'primary'
    },
    {
      label: 'asset.checkin',
      action: d => this.checkin(d),
      condition: d => d.checkoutId,
      type: 'primary'
    },
    {
      label: 'view',
      action: d => this.view(d),
      permissions: ['asset.manage', 'asset.view'],
      icon: 'eye'
    },
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['asset.manage', 'asset.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['asset.manage', 'asset.delete'],
      icon: 'delete'
    },
    // {
    //   label: 'depreciate',
    //   action: d => this.depreciate(d)
    // }
  ]

  constructor(
    private assetHttpService: AssetBaseHttpService,
    private activatedRoute: ActivatedRoute,
    private categoryHttpService: CategoryHttpService,
  ) {
    super(assetHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.gets();

    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  gets(pagination = null, search = null) {

    this.loading = true;
    const request = [
      this.categoryHttpService.listByParent(1, pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {

        this.categories = res[0].data.items;
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
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
    if (model) {
      this.goTo(`/admin/asset/${model.id}/view`);
    }
  }

  checkout(model) {
    if (model) {
      this.goTo(`/admin/asset/${model.id}/checkout`);
    }
  }

  checkin(model) {
    if (model) {
      this.goTo(`/admin/asset/${model.id}/checkin`);
    }
  }

  depreciate(model) {
    if (model) {
      this.loading = true;
      this.subscribe(this.assetHttpService.depreciate(model.id),
        res => {
          this.loading = false;
          this.success('success')
        },
        err => {
          this.loading = false;
          this.failed('failed')
        }
      );
    }
  }

}
