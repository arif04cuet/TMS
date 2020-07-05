import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { SessionProgressHttpService } from 'src/services/http/budget-and-schedule/session-progress-http.service';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-session-progress',
  templateUrl: './session-progress.component.html'
})
export class SessionProgressComponent extends TableComponent {

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
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

  load() {
    if (this.batchScheduleId) {
      this.setOfCheckedId = new Set<number>();
      super.load((p, s) => {
        return this.sessionProgressHttpService.list(this.batchScheduleId, this.module).pipe(
          map((x: any) => {
            x.data = x.data.map(y => {
              return {
                // disabled: y.completed,
                ...y
              }
            });
            return x;
          })
        );
      })
    }
  }

  markCompleteAndGenerateSheet(e) {
    this.loading = true;
    this.subscribe(this.sessionProgressHttpService.completeAndGenerateSheet(this.batchScheduleId, e.id),
      res => this.download(res),
      err => this.loading = false
    );
  }

  markCompleteMultipleAndGenerateSheet() {
    const routinePeriodIds = Array.from(this.setOfCheckedId);
    if (!routinePeriodIds) {
      this.failed('no.item.selected');
      return;
    }
    const body = {
      routinePeriods: routinePeriodIds
    }
    this.loading = true;
    this.subscribe(this.sessionProgressHttpService.completeMultipleAndGenerateSheet(this.batchScheduleId, body),
      res => this.download(res),
      err => this.loading = false
    );
  }

  markCompleteMultiple() {
    const routinePeriodIds = Array.from(this.setOfCheckedId);
    if (!routinePeriodIds) {
      this.failed('no.item.selected');
      return;
    }
    const body = {
      routinePeriods: routinePeriodIds,
      batchScheduleId: Number(this.batchScheduleId)
    };
    this.loading = true;
    this.subscribe(this.sessionProgressHttpService.completeMultiple(body),
      res => {
        this.load();
        this.success('success');
      },
      err => this.loading = false
    );
  }

  private download(res) {
    progress(res, null, (data: Blob) => {
      createAnchorAndFireForDownload(data, "honorarium-sheet.pdf");
      this.load();
      this.success('success');
    });
  }

}
