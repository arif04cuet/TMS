import { Component, ViewChild, Type, TemplateRef } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { NzModalService } from 'ng-zorro-antd';
import { TopicsModalComponent } from '../topics-modal/topics-modal.component';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';

@Component({
  selector: 'app-module-add',
  templateUrl: './module-add.component.html'
})
export class ModuleAddComponent extends FormComponent {

  loading: boolean = true;
  objectiveEditor = ClassicEditor;
  data: any = {};
  topics = [];

  @ViewChild('objectiveEditorComponent') objectiveEditorComponent: CKEditorComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;
  @ViewChild('directorSelect') directorSelect: SelectControlComponent;
  @ViewChild('coursesSelect') coursesSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private moduleHttpService: ModuleHttpService,
    private courseHttpService: CourseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator,
    private modal: NzModalService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      duration: [null, [], this.v.required.bind(this)],
      marks: [null, [], this.v.required.bind(this)],
      director: [null, [], this.v.required.bind(this)],
      courses: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.directorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.coursesSelect.register((pagination, search) => {
      return this.courseHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    body.objectives = this.objectiveEditorComponent.editorInstance.getData();
    body.topics = this.data.topics;

    this.submitForm(
      {
        request: this.moduleHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.moduleHttpService.edit(this.id, body),
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
      this.subscribe(this.moduleHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
          this.data = res.data;
          this.initModalData();
          this.setEditorData(this.data);
        }
      );
    }
    else {
      this.initModalData();
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/courses/modules');
  }

  setEditorData(data) {
    if (this.objectiveEditorComponent) {
      this.objectiveEditorComponent.editorInstance.setData(data.objectives);
    }
  }

  async addTopics() {
    const modal = this.createModal(TopicsModalComponent);
    const m = await this.t('x0.already.added', { x0: 'topic' });
    this.subscribe(modal.afterClose, res => {
      const topic = modal.getContentComponent().selectedTopic;
      if (topic) {
        const exist = this.data.topics.find(x => x.topic.id == topic.id);
        if (!exist) {
          this.data.topics = [...this.data.topics, {
            topic: topic,
            marks: topic.marks,
            duration: topic.duration
          }];
          this.calculateDuration();
          this.calculateMarks();
          this.appendObjectives(topic.objectives);
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
      nzComponentParams: {},
      nzFooter: this.modalFooter
    });
  }

  delete(e) {
    this.data.topics = this.data.topics.filter(x => x.id != e.id);
    this.calculateDuration();
    this.calculateMarks();
  }

  durationChanged() {
    this.calculateDuration();
  }

  marksChanged() {
    this.calculateMarks();
  }

  private initModalData() {
    if (!this.data.topics) {
      this.data.topics = []
    }
  }

  private appendObjectives(objectives) {
    if (this.objectiveEditorComponent) {
      let _objectives = this.objectiveEditorComponent.editorInstance.getData();
      _objectives += (objectives || "");
      this.objectiveEditorComponent.editorInstance.setData(_objectives);
    }
  }

  private calculateDuration() {
    const durations = this.data.topics.map(x => x.duration).reduce((a, c) => a + c);
    this.setValue('duration', durations);
  }

  private calculateMarks() {
    const marks = this.data.topics.map(x => x.marks).reduce((a, c) => a + c);
    this.setValue('marks', marks);
  }

}
