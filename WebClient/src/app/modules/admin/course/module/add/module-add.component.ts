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

  constructor(
    private activatedRoute: ActivatedRoute,
    private moduleHttpService: ModuleHttpService,
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
      director: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.directorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    body.objectives = this.objectiveEditorComponent.editorInstance.getData();
    body.topics = this.data.topics.map(x => x.id);

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
    const m = await this.t('x0.already.added', {x0: 'topic'});
    this.subscribe(modal.afterClose, res => {
      const topic = modal.getContentComponent().selectedTopic;
      if(topic) {
        const exist = this.data.topics.find(x => x.id == topic.id);
        if (!exist && topic) {
          this.data.topics = [...this.data.topics, topic];
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
  }

  private initModalData() {
    if (!this.data.topics) {
      this.data.topics = []
    }
  }

}
