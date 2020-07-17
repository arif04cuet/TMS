import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { MethodHttpService } from 'src/services/http/course/method-http.service';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

@Component({
  selector: 'app-topic-add',
  templateUrl: './topic-add.component.html'
})
export class TopicAddComponent extends FormComponent {

  loading: boolean = true;
  objectiveEditor = ClassicEditor;
  outcomeEditor = ClassicEditor;
  materialEditor = ClassicEditor;
  detailsEditor = ClassicEditor;
  data: any = {};

  @ViewChild('objectiveEditorComponent') objectiveEditorComponent: CKEditorComponent;
  @ViewChild('outcomeEditorComponent') outcomeEditorComponent: CKEditorComponent;
  @ViewChild('materialEditorComponent') materialEditorComponent: CKEditorComponent;
  @ViewChild('detailsEditorComponent') detailsEditorComponent: CKEditorComponent;

  @ViewChild('resourcePersonSelect') resourcePersonSelect: SelectControlComponent;
  @ViewChild('methodSelect') methodSelect: SelectControlComponent;
  @ViewChild('evaluationMethodSelect') evaluationMethodSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private topicHttpService: TopicHttpService,
    private v: CommonValidator,
    private resourcePersonHttpService: ResourcePersonHttpService,
    private methodHttpService: MethodHttpService,
    private evaluationMethodHttpService: EvaluationMethodHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      resourcePersons: [],
      method: [null, [], this.v.required.bind(this)],
      evaluationMethod: [null, [], this.v.required.bind(this)],
      duration: [null, [], this.v.required.bind(this)],
      marks: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    //this.setEditorData(this.data);
    this.resourcePersonSelect.register((pagination, search) => {
      return this.resourcePersonHttpService.list(pagination, search);
    }).fetch();

    this.methodSelect.register((pagination, search) => {
      return this.methodHttpService.list(pagination, search);
    }).fetch();

    this.evaluationMethodSelect.register((pagination, search) => {
      return this.evaluationMethodHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    body.objectives = this.objectiveEditorComponent.editorInstance.getData();
    body.outcomes = this.outcomeEditorComponent.editorInstance.getData();
    body.courseMaterials = this.materialEditorComponent.editorInstance.getData();
    body.courseDetails = this.detailsEditorComponent.editorInstance.getData();

    this.submitForm(
      {
        request: this.topicHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.topicHttpService.edit(this.id, body),
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
      this.subscribe(this.topicHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
          this.data = res.data;
          this.setEditorData(this.data);
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/courses/topics');
  }

  validateEditor() {
    //console.log(this.objectiveEditorComponent);
  }

  setEditorData(data) {
    if (this.objectiveEditorComponent) {
      this.objectiveEditorComponent.editorInstance.setData(data.objectives);
      this.outcomeEditorComponent.editorInstance.setData(data.outcomes);
      this.materialEditorComponent.editorInstance.setData(data.courseMaterials);
      this.detailsEditorComponent.editorInstance.setData(data.courseDetails);
    }
  }

}
