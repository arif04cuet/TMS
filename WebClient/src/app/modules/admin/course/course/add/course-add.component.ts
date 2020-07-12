import { Component, ViewChild, Type, TemplateRef } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import { NzModalService } from 'ng-zorro-antd';
import { ModuleModalComponent } from '../module-modal/module-modal.component';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { CategoryHttpService } from 'src/services/http/course/category-http.service';
import { EvaluationMethodModalComponent } from '../evaluation-method-modal/evaluation-method-modal.component';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { MethodHttpService } from 'src/services/http/course/method-http.service';

@Component({
  selector: 'app-course-add',
  templateUrl: './course-add.component.html'
})
export class CourseAddComponent extends FormComponent {

  loading: boolean = true;
  objectiveEditor = ClassicEditor;
  descriptionEditor = ClassicEditor;
  data: any = {};

  @ViewChild('objectiveEditorComponent') objectiveEditorComponent: CKEditorComponent;
  @ViewChild('descriptionEditorComponent') descriptionEditorComponent: CKEditorComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;
  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('methodSelect') methodSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseHttpService: CourseHttpService,
    private methodHttpService: MethodHttpService,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator,
    private modal: NzModalService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      category: [null, [], this.v.required.bind(this)],
      totalMark: [null, [], this.v.required.bind(this)],
      duration: [null, [], this.v.required.bind(this)],
      methods: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.categorySelect.register((pagination, search) => {
      return this.categoryHttpService.list(pagination, search);
    }).fetch();

    this.methodSelect.register((pagination, search) => {
      return this.methodHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    body.objective = this.objectiveEditorComponent.editorInstance.getData();
    body.description = this.descriptionEditorComponent.editorInstance.getData();
    body.modules = this.data.modules.map(x => x.id);
    body.evaluationMethods = this.data.evaluationMethods;

    if(!body.methods) {
      body.methods = [];
    }

    this.submitForm(
      {
        request: this.courseHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.courseHttpService.edit(this.id, body),
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
      this.subscribe(this.courseHttpService.get(id),
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
    this.goTo('/admin/courses');
  }

  setEditorData(data) {
    if (this.objectiveEditorComponent) {
      this.objectiveEditorComponent.editorInstance.setData(data.objective);
    }
    if (this.descriptionEditorComponent) {
      this.descriptionEditorComponent.editorInstance.setData(data.description);
    }
  }

  async addModules() {
    const modal = this.createModal(ModuleModalComponent);
    const m = await this.t('x0.already.added', {x0: 'module'});
    this.subscribe(modal.afterClose, res => {
      const module = modal.getContentComponent().selectedItem;
      if(module) {
        const exist = this.data.modules.find(x => x.id == module.id);
        if (!exist && module) {
          this.data.modules = [...this.data.modules, {
            courseModule: module,
            marks: module.marks,
            duration: module.duration
          }];
          this.calculateDuration();
          this.calculateMarks();
        }
        else {
          this.info(m);
        }
      }
    });
  }

  async addEvaluationMethods() {
    const m = await this.t('x0.already.added', {x0: 'evaluation.method'});
    const modal = this.createModal(EvaluationMethodModalComponent);
    this.subscribe(modal.afterClose, res => {
      const evaluationMethod = modal.getContentComponent().selectedItem;
      if(evaluationMethod) {
        const exist = this.data.evaluationMethods.find(x => x.evaluationMethod.id == evaluationMethod.id);
        if (!exist) {
          this.data.evaluationMethods = [...this.data.evaluationMethods, {
            evaluationMethod: evaluationMethod,
            mark: evaluationMethod.mark
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
      nzComponentParams: {},
      nzFooter: this.modalFooter
    });
  }

  deleteModule(e) {
    this.data.modules = this.data.modules.filter(x => x.id != e.id);
  }

  deleteEvaluationMethod(e) {
    this.data.evaluationMethods = this.data.evaluationMethods.filter(x => x.id != e.id);
  }

  private initModalData() {
    if(!this.data.modules) {
      this.data.modules = [];
    }
    if(!this.data.evaluationMethods) {
      this.data.evaluationMethods = [];
    }
  }

  durationChanged() {
    this.calculateDuration();
  }

  marksChanged() {
    this.calculateMarks();
  }

  private calculateDuration() {
    const durations = this.data.topics.map(x => x.duration).reduce((a, c) => a + c);
    this.setValue('duration', durations);
  }

  private calculateMarks() {
    const marks = this.data.topics.map(x => x.marks).reduce((a, c) => a + c);
    this.setValue('totalMark', marks);
  }

}
