import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';


@Component({
  selector: 'app-depreciation-report',
  templateUrl: './depreciation-report.component.html'
})
export class DepreciationReportComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private id;

  constructor(
    private assetReportHttpService: AssetReportsHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetReportHttpService);
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
      return this.assetReportHttpService.depreciation(p, s);
    });
  }

}
