import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';

@Component({
  selector: 'app-honorarium',
  templateUrl: './honorarium.component.html'
})
export class HonorariumComponent extends TableComponent {

  private batchScheduleId;

  constructor(
    private batchScheduleHttpService: BatchScheduleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(batchScheduleHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.batchScheduleId = snapshot.params.id;
  }

  downloadSheet() {
    this.loading = true;
    this.subscribe(this.batchScheduleHttpService.downloadHonorariumSheet(this.batchScheduleId),
      res => {
        this.loading = false;
        this.download(res);
      },
      err => this.loading = false
    );
  }
  
  private download(res) {
    progress(res, null, (data: Blob) => {
      createAnchorAndFireForDownload(data, "participants-honorarium-sheet.pdf");
      this.success('success');
    });
  }

}
