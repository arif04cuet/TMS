import { Component, Output, EventEmitter } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html'
})
export class ExamListComponent extends TableComponent {

  private batchScheduleId;
  @Output() onAction = new EventEmitter();

  constructor(
    private examHttpService: ExamHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(examHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.onAction.emit({
        action: 'edit',
        data: model
      });
    }
    else {
      this.onAction.emit({
        action: 'add'
      });
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

  load() {
    super.load((p, s) => {
      return this.examHttpService.list2(this.batchScheduleId, p, s);
    });
  }

}
