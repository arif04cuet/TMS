import { Component, ViewChild } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { BatchScheduleAllocationHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-allocation-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { map } from 'rxjs/operators';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';

@Component({
  selector: 'app-batch-schedule-allocation-list',
  templateUrl: './batch-schedule-allocation-list.component.html'
})
export class BatchScheduleAllocationListComponent extends TableComponent {

  @ViewChild('batchScheduleSelect') batchScheduleSelect: SelectComponent;
  @ViewChild('courseSelect') courseSelect: SelectComponent;
  @ViewChild('statusSelect') statusSelect: SelectComponent;

  serverUrl = environment.serverUri;
  statuses = [];

  constructor(
    private batchScheduleAllocationHttpService: BatchScheduleAllocationHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private courseHttpService: CourseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(batchScheduleAllocationHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  ngAfterViewInit() {
    this.batchScheduleSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.list(pagination, search).pipe(
        map((x: any) => {
          if (x.data && x.data.items && x.data.items.length) {
            x.data.items.forEach(item => {
              item.name = item.courseSchedule.name;
            });
          }
          return x;
        })
      );
    }).fetch();

    this.courseSelect.register((pagination, search) => {
      return this.courseHttpService.list(pagination, search);
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return this.batchScheduleAllocationHttpService.listStatus();
    }).fetch();

  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/trainings/batch-schedules/allocations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/trainings/batch-schedules/allocations/add');
    }
  }

  gets() {
    this.internalLoad();
    this.subscribe(this.batchScheduleAllocationHttpService.listStatus(),
      (res: any) => {
        this.statuses = res.data.items;
      }
    )
  }

  mark(e) {
    console.log(e);
    this.loading = true;
    const body = {
      ids: Array.from(this.setOfCheckedId),
      status: e
    }
    this.subscribe(this.batchScheduleAllocationHttpService.updateStatus(body),
      (res: any) => {
        this.loading = false;
        this.success('success');
      },
      err => {
        this.loading = false;
        this.failed('failed');
      }
    );
  }

  refresh() {
    this.internalLoad();
  }

  search() {
    this.internalLoad();
  }

  internalLoad() {
    this.load((p, s) => {
      return this.batchScheduleAllocationHttpService.list(p, this.getSearch());
    });
  }

  export() {
    this.subscribe(this.batchScheduleAllocationHttpService.export(this.getSearch()),
      res => {
        progress(res, null, (data: Blob) => {
          this.success('success');
          createAnchorAndFireForDownload(data, "batch-schedule-allocation.csv");
        });
      },
      err => {
        //
      }
    )
  }

  getSearch() {
    let search = '';
    if (this.courseSelect?.value) {
      search += `Search=CourseId eq ${this.courseSelect.value}&`;
    }
    if (this.batchScheduleSelect?.value) {
      search += `Search=BatchScheduleId eq ${this.batchScheduleSelect.value}&`;
    }
    if (this.statusSelect?.value) {
      search += `Search=Status eq ${this.statusSelect.value}`;
    }
    return search;
  }

}
