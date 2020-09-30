import { Component, Output, EventEmitter } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';
import { progress, createAnchorAndFireForDownload } from 'src/services/utilities.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html'
})
export class ExamListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("ExamDate", "eq") examDate;
  @Output() onAction = new EventEmitter();
  private batchScheduleId;

  buttons: IButton[] = [
    {
      label: 'result',
      action: d => this.result(d),
      condition: d => d.isOnline && d.questionType != null
    },
    {
      label: 'edit',
      action: d => this.add(d),
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      icon: 'delete'
    }
  ]

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

  download(res) {
    this.subscribe(this.examHttpService.download(res.id),
      res => progress(res, null, (data: Blob) => {
        createAnchorAndFireForDownload(data, "exam-paper.pdf");
        this.load();
        this.success('success');
      }),
      err => this.loading = false
    );
  }

}
