import { Component, Output, Input, EventEmitter } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FormComponent } from 'src/app/shared/form.component';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';

@Component({
  selector: 'app-exam-answer',
  templateUrl: './exam-answer.component.html',
  styleUrls: ['./exam-answer.component.scss']
})
export class ExamAnswerComponent extends FormComponent {

  loading: boolean = false;
  data: any = {}
  serverUrl = environment.serverUri;
  @Output() onAction = new EventEmitter();
  @Input() model;

  constructor(
    private examHttpService: ExamHttpService
  ) {
    super();
  }

  ngOnInit() {
    this.get();
  }

  get() {
    this.loading = true;
    this.subscribe(this.examHttpService.answer(this.model.participantId, this.model.examId),
      (res: any) => {
        this.loading = false;
        this.data = res.data;
      },
      (err: any) => {
        this.loading = false;
      }
    );
  }

  cancel() {
    this.onAction.emit({
      action: 'cancel'
    });
  }

}
