import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';

@Component({
  selector: 'app-requisition-asset-list',
  templateUrl: './asset-list.component.html'
})
export class AssetListComponent extends TableComponent {

  @Input() data: any;

  status = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("AssetTag", "like") assetTag;
  @Searchable("Name", "like") name;
  @Searchable("Category.Name", "like") category;

  constructor(
    private assetHttpService: AssetBaseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    if (this.data && this.data.assets) {
      this.setOfCheckedId = new Set<number>(this.data.assets.map(x => x.id));
    }
    this.load();
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  ngOnDestroy() {
    if (this.data) {
      this.data.assets = Array.from(this.setOfCheckedId).map(x => {
        return this.items.find(y => y.id == x);
      });
    }
  }

}
