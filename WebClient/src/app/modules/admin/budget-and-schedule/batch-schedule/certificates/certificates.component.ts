import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { BatchScheduleAllocationHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-allocation-http.service';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';

@Component({
  selector: 'app-certificates',
  templateUrl: './certificates.component.html'
})
export class CertificatesComponent extends TableComponent {

  private id;

  constructor(
    private batchScheduleHttpService: BatchScheduleHttpService,
    private batchScheduleAllocationHttpService: BatchScheduleAllocationHttpService,
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

  downloadCertificate(model) {
    if(model) {
      this.loading = true;
      this.subscribe(this.batchScheduleAllocationHttpService.downloadCertificate(model.batchScheduleAllocationId),
        res => {
          this.loading = false;
          this.download(res);
        },
        err => this.loading = false
      );
    }
  }
  
  private download(res) {
    progress(res, null, (data: Blob) => {
      createAnchorAndFireForDownload(data, "certificate.pdf");
      this.success('success');
    });
  }

}
