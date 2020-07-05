import { Component, Output, EventEmitter, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { TableComponent } from 'src/app/shared/table.component';

@Component({
  selector: 'app-total-mark',
  templateUrl: './total-mark.component.html'
})
export class TotalMarkComponent extends TableComponent {

  loading: boolean = false;
  @Output() onAction = new EventEmitter();
  @Input() model;

  private batchScheduleId;
  private examId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private examHttpService: ExamHttpService,
    private v: CommonValidator
  ) {
    super(examHttpService);
  }

  ngOnInit(): void {

    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;

    if (this.model && this.model.id) {
      this.examId = this.model.id;
      this.load();
    }
  }

  submit(): void {
    const body = {
      marks: this.items
    }
    this.subscribe(this.examHttpService.updateResult(this.examId, body),
      res => {
        this.loading = false;
        this.cancel();
        this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
      },
      err => this.loading = false
    );
  }

  cancel() {
    this.onAction.emit({
      action: 'cancel'
    });
  }

  load() {
    return super.load((p, s) => this.examHttpService.result(this.batchScheduleId, this.examId));
  }

  refresh() {
    this.load();
  }

  markChanged(d, e) {
    const n = Number(e);
    if(n) {
      d.mark = n;
    }
  }

}
