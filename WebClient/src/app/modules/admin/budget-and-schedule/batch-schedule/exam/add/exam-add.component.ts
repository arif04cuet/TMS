import { Component, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';

@Component({
  selector: 'app-exam-add',
  templateUrl: './exam-add.component.html'
})
export class ExamAddComponent extends FormComponent {

  loading: boolean = false;
  @Output() onAction = new EventEmitter();
  @Input() model;
  
  @ViewChild('typeSelect') typeSelect: SelectControlComponent;
  @ViewChild('statusSelect') statusSelect: SelectControlComponent;

  private batchScheduleId;
  private examId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private examHttpService: ExamHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      evaluationMethod: [null, [], this.v.required.bind(this)],
      mark: [null, [], this.v.required.bind(this)],
      totalMinutes: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      examDate: [null, [], this.v.required.bind(this)]
    });

    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;

    if(this.model && this.model.id) {
      this.examId = this.model.id;
      this.markModeAsEdit();
      this.get(this.examId);
    }
    else {
      this.markModeAsAdd();
    }
  }

  ngAfterViewInit() {
    this.typeSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.listEvaluationMethods(this.batchScheduleId, pagination, search);
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return this.examHttpService.listStatus();
    }).fetch();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if(this.batchScheduleId) {
      body.batchSchedule = Number(this.batchScheduleId);
    }
    this.submitForm(
      {
        request: this.examHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.examHttpService.edit(this.examId, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.examHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        },
        err => {
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.onAction.emit({
      action: 'cancel'
    });
  }

}
