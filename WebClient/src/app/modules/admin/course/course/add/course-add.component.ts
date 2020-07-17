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
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-course-add',
  templateUrl: './course-add.component.html'
})
export class CourseAddComponent extends FormComponent {

  loading: boolean = true;
  objectiveEditor = ClassicEditor;
  descriptionEditor = ClassicEditor;
  data: any = {};

  imageUrl;
  imageLoading = false;



  @ViewChild('objectiveEditorComponent') objectiveEditorComponent: CKEditorComponent;
  @ViewChild('descriptionEditorComponent') descriptionEditorComponent: CKEditorComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;
  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('methodSelect') methodSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseHttpService: CourseHttpService,
    private moduleHttpService: ModuleHttpService,
    private methodHttpService: MethodHttpService,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator,
    private modal: NzModalService,
    private mediaHttpService: MediaHttpService
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
      methods: [],
      image: []
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

  handlePhotoChange(e) {
    const file = e.target.files[0];
    if (file) {
      this.imageLoading = true;
      var fr = new FileReader();
      fr.onload = () => {
        this.imageUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          this.log('progress', progress);
        },
        success => {
          this.log('success', success);
          this.form.controls.image.setValue(success.data);
          this.imageLoading = false;
        },
        error => {
          this.imageLoading = false;
        }
      );
    }
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    body.objective = this.objectiveEditorComponent.editorInstance.getData();
    body.description = this.descriptionEditorComponent.editorInstance.getData();
    body.modules = this.data.modules;
    body.evaluationMethods = this.data.evaluationMethods;

    if (!body.methods) {
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
          if (res.data.image) {
            this.imageUrl = `${environment.serverUri}/${res.data.imageUrl}`;

          }
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
    const m = await this.t('x0.already.added', { x0: 'module' });
    this.subscribe(modal.afterClose, res => {
      const module = modal.getContentComponent().selectedItem;
      if (module) {
        const exist = this.data.modules.find(x => x.courseModule.id == module.id);
        if (!exist && module) {
          this.data.modules = [...this.data.modules, {
            courseModule: module,
            marks: module.marks,
            duration: module.duration
          }];
          this.calculateDuration();
          this.calculateMarks();
          this.appendObjectives(module.objectives);

          this.subscribe(this.moduleHttpService.listMethods(module.id),
            (res: any) => {
              if (res.data && res.data.items) {
                const methods = res.data.items.map(x => x.id);
                const oldMethods = this.form.controls.methods.value
                const sets = new Set<number>(methods.concat(oldMethods));
                this.setValue('methods', Array.from(sets));
              }
            },
            err => { }
          );
        }
        else {
          this.info(m);
        }
      }
    });
  }

  async addEvaluationMethods() {
    const m = await this.t('x0.already.added', { x0: 'evaluation.method' });
    const modal = this.createModal(EvaluationMethodModalComponent);
    this.subscribe(modal.afterClose, res => {
      const evaluationMethod = modal.getContentComponent().selectedItem;
      if (evaluationMethod) {
        const exist = this.data.evaluationMethods.find(x => x.evaluationMethod.id == evaluationMethod.id);
        if (!exist) {

          // check total course marks
          const totalEvaluationMark = this.calculateTotalEvaluationMark() + evaluationMethod.mark
          const totalMark = this.form.controls.totalMark.value;
          if (totalEvaluationMark > totalMark) {
            const exceed = totalEvaluationMark - totalMark;
            evaluationMethod.mark = 0;
          }

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
    this.calculateDuration();
    this.calculateMarks();
  }

  deleteEvaluationMethod(e) {
    this.data.evaluationMethods = this.data.evaluationMethods.filter(x => x.id != e.id);
  }

  private initModalData() {
    if (!this.data.modules) {
      this.data.modules = [];
    }
    if (!this.data.evaluationMethods) {
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
    const durations = this.data.modules.map(x => x.duration).reduce((a, c) => a + c);
    this.setValue('duration', durations);
  }

  private calculateTotalEvaluationMark() {
    let total = 0;
    if (this.data.evaluationMethods) {
      total = this.data.evaluationMethods.map(x => x.mark).reduce((a, c) => a + c);
    }
    return total;
  }

  private calculateMarks() {
    const marks = this.data.modules.map(x => x.marks).reduce((a, c) => a + c);
    this.setValue('totalMark', marks);
  }

  private appendObjectives(objectives) {
    if (this.objectiveEditorComponent) {
      let _objectives = this.objectiveEditorComponent.editorInstance.getData();
      _objectives += (objectives || "");
      this.objectiveEditorComponent.editorInstance.setData(_objectives);
    }
  }

}
