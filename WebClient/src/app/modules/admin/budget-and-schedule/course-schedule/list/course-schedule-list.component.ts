import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-course-schedule-list',
  templateUrl: './course-schedule-list.component.html'
})
export class CourseScheduleListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['schedule.manage', 'schedule.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['schedule.manage', 'schedule.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private courseScheduleHttpService: CourseScheduleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(courseScheduleHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/trainings/course-schedules/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/trainings/course-schedules/add');
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
