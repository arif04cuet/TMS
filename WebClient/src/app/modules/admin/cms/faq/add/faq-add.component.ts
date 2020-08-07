import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { FaqHttpService } from 'src/services/http/cms/faq-http.service';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-faq-add',
  templateUrl: './faq-add.component.html'
})
export class FaqAddComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};
  answerEditor = ClassicEditor;

  @ViewChild('answerEditorComponent') answerEditorComponent: CKEditorComponent;
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private faqHttpService: FaqHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      question: [null, [], this.v.required.bind(this)],
      isActive:[]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body:any = this.constructObject(this.form.controls);
    body.answer = this.answerEditorComponent.editorInstance.getData();

    this.submitForm(
      {
        request: this.faqHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.faqHttpService.edit(this.id, body),
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
      this.subscribe(this.faqHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.data = res.data;
         
          this.setEditorData(this.data);

          this.loading = false;
          
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/cms/faq');
  }

  setEditorData(data) {
    
    if (this.answerEditorComponent) {
       this.answerEditorComponent.editorInstance.setData(data.answer);
    }
  }

}
