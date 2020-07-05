import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { SessionProgressHttpService } from 'src/services/http/budget-and-schedule/session-progress-http.service';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';

@Component({
  selector: 'app-honorarium',
  templateUrl: './honorarium.component.html'
})
export class HonorariumComponent extends TableComponent {

  module;
  private batchScheduleId;

  constructor(
    private sessionProgressHttpService: SessionProgressHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(sessionProgressHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.batchScheduleId = snapshot.params.id;
    this.gets();
  }

  gets() {
    //this.load();
  }

  GenerateSheet() {
    this.loading = true;
    // this.subscribe(this.sessionProgressHttpService.completeAndGenerateSheet(this.batchScheduleId, e.id),
    //   res => this.download(res),
    //   err => this.loading = false
    // );
  }
  
  private download(res) {
    progress(res, null, (data: Blob) => {
      createAnchorAndFireForDownload(data, "honorarium-sheet.pdf");
      this.load();
      this.success('success');
    });
  }

}
