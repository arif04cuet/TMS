import { Component, Output, EventEmitter } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-my-exam-list',
  templateUrl: './my-exam-list.component.html'
})
export class MyExamListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("ExamDate", "eq") examDate;
  @Output() onAction = new EventEmitter();
  private batchScheduleId;

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

  result(e) {
    this.onAction.emit({
      action: 'result',
      data: e
    });
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

  download(exam) {
    this.log('download exam', exam);
  }

}
