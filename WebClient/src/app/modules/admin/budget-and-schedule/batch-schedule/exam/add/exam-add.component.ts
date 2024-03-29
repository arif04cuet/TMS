import { Component, ViewChild, Output, EventEmitter, Input, Type } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { of } from 'rxjs';
import { QuestionModalComponent } from '../question-modal/question-modal.component';
import { NzModalService } from 'ng-zorro-antd';
import { MomentPipe } from 'src/pipes/moment.pipe';

@Component({
  selector: 'app-exam-add',
  templateUrl: './exam-add.component.html'
})
export class ExamAddComponent extends FormComponent {

  loading: boolean = false;
  data: any = {};
  showQuestionTypeInput = false;

  @Output() onAction = new EventEmitter();
  @Input() model;

  @ViewChild('typeSelect') typeSelect: SelectControlComponent;
  @ViewChild('evaluationTypeSelect') evaluationTypeSelect: SelectControlComponent;
  @ViewChild('questionTypeSelect') questionTypeSelect: SelectControlComponent;
  @ViewChild('statusSelect') statusSelect: SelectControlComponent;


  private batchScheduleId;
  private examId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private examHttpService: ExamHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private v: CommonValidator,
    private modal: NzModalService,
    private momentPipe: MomentPipe
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
      examDate: [null, [], this.v.required.bind(this)],
      extraTime: [],
      evaluationType: [],
      questionType: [],
      isOnline: [],
      questions: []
    });

    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;

    if (this.model && this.model.id) {
      this.examId = this.model.id;
      this.markModeAsEdit();
      this.get(this.examId);
    }
    else {
      this.markModeAsAdd();
      this.initModalData();
    }
  }

  ngAfterViewInit() {
    this.typeSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.listEvaluationMethods(this.batchScheduleId, pagination, search);
    })
      .onLoadCompleted((items: any[]) => {
        const e = this.form.controls.evaluationMethod.value;
        this.showHideQuestionTypeInput(e, items);
      })
      .fetch();

    this.questionTypeSelect.register((pagination, search) => {
      return of({
        data: {
          items: [
            { id: 1, name: 'MCQ' },
            { id: 2, name: 'Written' },
          ],
          size: 2
        }
      });
    }).fetch();

    this.evaluationTypeSelect.register((pagination, search) => {
      return of({
        data: {
          items: [
            { id: 1, name: 'Pre Training' },
            { id: 2, name: 'In Training' },
            { id: 3, name: 'Post Training' }
          ],
          size: 3
        }
      });
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return this.examHttpService.listStatus();
    }).fetch();
  }

  submit(): void {

    if(this.questionMarkHasZeroValue()) {
      this.failed('question.marks.can.not.have.zero');
      return;
    }

    if(this.calculateMarks() != Number(this.form.controls.mark.value || 0)) {
      this.failed('exam.mark.and.question.total.mark.must.be.same');
      return;
    }

    const body: any = this.constructObject(this.form.controls);
    if (this.batchScheduleId) {
      body.batchSchedule = Number(this.batchScheduleId);
    }
    if (!this.showQuestionTypeInput) {
      delete body.questionType;
    }
    body.questions = this.data.questions;
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
          res.data.examDate = this.momentPipe.transform(res.data.examDate)
          this.setValues(this.form.controls, res.data);
          this.data = res.data;
          this.initModalData();
          this.loading = false;
        },
        err => {
          this.initModalData();
          this.loading = false;
        }
      );
    }
    else {
      this.initModalData();
      this.loading = false;
      this.setValue('evaluationType', 2);
      this.setValue('status', 2);
      
      
    }
  }

  cancel() {
    this.onAction.emit({
      action: 'cancel'
    });
  }

  examTypeChanged(e) {
    this.showHideQuestionTypeInput(e);
  }

  async addQuestion() {
    const modal = this.createModal(QuestionModalComponent);
    const m = await this.t('x0.already.added', { x0: 'question' });
    this.subscribe(modal.afterClose, res => {
      const question = modal.getContentComponent().selectedItem;
      if (question) {
        const exist = this.data.questions.find(x => x.question.id == question.id);
        if (!exist && question) {
          // check total question marks
          const totalMarks = this.calculateMarks();
          const totalQuestionMark = totalMarks + question.mark
          const totalMark = Number(this.form.controls.mark.value);
          if (totalQuestionMark > totalMark) {
            const exceed = totalQuestionMark - totalMark;
            const rest = question.mark - exceed;
            const mark = (totalMarks + rest) > totalMark ? 0 : rest;
            question.mark = mark;
          }
          this.data.questions = [...this.data.questions, {
            question: question,
            mark: question.mark
          }];
        }
        else {
          this.info(m);
        }
      }
    });
  }

  createModal<T>(component: Type<T>) {
    return this.modal.create({
      nzWidth: '80%',
      nzContent: component,
      nzGetContainer: () => document.body,
      nzComponentParams: <any>{
        questionType: this.form.controls.questionType.value
      },
      nzFooter: null
    });
  }

  deleteQuestion(q) {
    this.data.questions = this.data.questions.filter(x => x.question.id != q.question.id);
  }

  private showHideQuestionTypeInput(e, items?: any[]) {
    if (e) {
      const _items = items || this.typeSelect.items;
      const item = _items.find(x => x.id == e);
      this.showQuestionTypeInput = item && item.name?.trim()?.toLowerCase() == "written";
    }
  }

  private initModalData() {
    if (!this.data.questions) {
      this.data.questions = [];
    }
  }

  private calculateMarks() {
    let total = 0;
    if (this.data.questions && this.data.questions.length) {
      total = this.data.questions.map(x => x.mark).reduce((a, c) => a + c);
    }
    return total;
  }

  private questionMarkHasZeroValue() {
    if (this.data.questions && this.data.questions.length) {
      return this.data.questions.some(x => !x.mark);
    }
    return false;
  }

}
