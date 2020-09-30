import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-batch-schedule-list',
  templateUrl: './batch-schedule-list.component.html'
})
export class BatchScheduleListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['batch.manage', 'batch.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['batch.manage', 'batch.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private batchScheduleHttpService: BatchScheduleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(batchScheduleHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/trainings/batch-schedules/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/trainings/batch-schedules/add');
    }
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

}
