import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import { FormArray, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-question-add',
  templateUrl: './question-add.component.html'
})
export class QuestionAddComponent extends FormComponent {

  loading: boolean = true;
  selectedType;
  @ViewChild('typeSelect') typeSelect: SelectControlComponent;
  @ViewChild('topicSelect') topicSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private questionHttpService: QuestionHttpService,
    private TopicHttpService: TopicHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      type: [null, [], this.v.required.bind(this)],
      topics: [null, [], this.v.required.bind(this)],
      answerLength: [],
      title: [null, [], this.v.required.bind(this)],
      mark: [null, [], this.v.required.bind(this)],
      options: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.typeSelect.register((pagination, search) => {
      return this.questionHttpService.listTypes();
    }).fetch();

    this.topicSelect.register((pagination, search) => {
      return this.TopicHttpService.list();
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.questionHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.questionHttpService.edit(this.id, body),
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
      this.subscribe(this.questionHttpService.get(id),
        (res: any) => {
          this.selectedType = res.data.type?.id;
          this.setValues(this.form.controls, res.data, ['options']);
          this.form.controls.options = this.fb.array([]);
          this.prepareForm(res);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/trainings/questions');
  }

  onTypeChanged(e) {
    this.selectedType = e;
  }

  addOption() {
    this.createOptionFormGroup({});
    //this.createOptionFormGroup({ isCorrect: false });
  }

  deleteOption(index) {
    const optionFormArray = this.getOptionFormArray();
    if (optionFormArray.controls && optionFormArray.controls.length) {
      optionFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.options?.length) {
      res.data.options.forEach(x => {
        this.createOptionFormGroup(x);
      });
    }
  }

  private createOptionFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      option: [null, [], this.v.required.bind(this)],
      isCorrect: []
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const optionFormArray = this.getOptionFormArray();
    optionFormArray.push(formGroup);
  }

  private getOptionFormArray(): FormArray {
    return this.form.get("options") as FormArray;
  }

}
