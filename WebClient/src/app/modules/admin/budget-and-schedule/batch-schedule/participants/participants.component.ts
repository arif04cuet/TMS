import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';

@Component({
  selector: 'app-participants',
  templateUrl: './participants.component.html'
})
export class ParticipantsComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;
  private id;

  constructor(
    private batchScheduleHttpService: BatchScheduleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(batchScheduleHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.id = snapshot.params.id;
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
    if (this.id) {
      super.load((p, s) => {
        return this.batchScheduleHttpService.listParticipant(this.id, p, s);
      })
    }
  }

}
