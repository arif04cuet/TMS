import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ContentHttpService } from 'src/services/http/cms/content-http.service';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';



@Component({
  selector: 'app-content-add',
  templateUrl: './content-add.component.html'
})
export class ContentAddComponent extends FormComponent {

  loading: boolean = true;
  bodyEditor = ClassicEditor;

  imageUrl;
  imageLoading = false;

  attachmentUrl;
  attachmentLoading = false;
  data: any = {};

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('bodyEditorComponent') bodyEditorComponent: CKEditorComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private contentHttpService: ContentHttpService,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      image: [],
      attachment: [],
      isActive: [],
      categoryId: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.categorySelect.register((pagination, search) => {
      return this.categoryHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    //const body = this.constructObject(this.form.controls);

    const body: any = this.constructObject(this.form.controls);
    body.body = this.bodyEditorComponent.editorInstance.getData();


    this.submitForm(
      {
        request: this.contentHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.contentHttpService.edit(this.id, body),
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
      this.subscribe(this.contentHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.form.controls.categoryId.setValue(res.data.category.id);
          this.loading = false;
          this.data = res.data;
          this.setEditorData(this.data);

          if (res.data.image) {
            this.imageUrl = `${environment.serverUri}/${res.data.imageUrl}`;

          }
          if (res.data.attachment) {
            this.attachmentUrl = `${environment.serverUri}/${res.data.attachmentUrl}`;
            this.form.controls.attachment.setValue(res.data.attachment.id);

          }


        }
      );
    }
    else {
      this.form.controls.isActive.setValue(true);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/cms/contents');
  }

  imageDeleteHandler = imageId => {
    return this.contentHttpService
      .deleteImage(imageId, this.id || null)
      .pipe(
        map(x => {
          console.log('image deleted', x);
          return true
        }),
        catchError(_ => of(false))
      );
  }

  attachmentDeleteHandler = attachmentId => {
    return this.contentHttpService
      .deleteAttachment(attachmentId, this.id || null)
      .pipe(
        map(x => {
          console.log('attachment deleted', x);
          return true
        }),
        catchError(_ => of(false))
      );
  }

  setEditorData(data) {
    if (this.bodyEditorComponent) {
      this.bodyEditorComponent.editorInstance.setData(data.body);
    }
  }

}
