import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';


@Component({
  selector: 'app-depreciation-schedule-report',
  templateUrl: './depreciation-schedule-report.component.html'
})
export class DepreciationScheduleReportComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private assetId;

  constructor(
    private assetReportHttpService: AssetReportsHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(assetReportHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.assetId = Number(this._activatedRouteSnapshot.params.assetId) || 0;
    this.load();
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  back_to_list() {

    this.goTo('/admin/asset/reports/depreciation');

  }

  load() {
    super.load((p, s) => {
      return this.assetReportHttpService.depreciationSchedule(this.assetId, p, s);
    });
  }

}
