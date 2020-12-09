import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { forEachObj, convertValueToEnglish } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { SubjectHttpService } from 'src/services/http/subject-http.service';
import { environment } from 'src/environments/environment';
import { MediaHttpService } from 'src/services/http/media-http.service';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.scss']
})
export class BookAddComponent extends FormComponent {

  loading: boolean = true;
  languages = [];
  publishers = [];
  authors = [];
  subjects = [];
  data;
  environment = environment;

  photoUrl;

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private authorHttpService: AuthorHttpService,
    private publisherHttpService: PublisherHttpService,
    private commonHttpService: CommonHttpService,
    private subjectHttpService: SubjectHttpService,
    private mediaHttpService: MediaHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      title: [null, [], this.v.required.bind(this)],
      isbn: [null, [], this.v.isbn.bind(this)],
      language: [null, [], this.v.required.bind(this)],
      publisher: [null, [], this.v.required.bind(this)],
      subjects: [],
      author: [null, [], this.v.required.bind(this)],
      mediaId: [],
      editions: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);

    console.log(body);
    //convert eng number to bangla
    for (let index = 0; index < body.editions.length; index++) {
      if (body.editions[index].numberOfPage)
        body.editions[index].numberOfPage = Number(convertValueToEnglish(body.editions[index].numberOfPage));
    }

    this.submitForm(
      {
        request: this.bookHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.bookHttpService.edit(this.id, body),
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
      this.subscribe(this.bookHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.setValues(this.form.controls, res.data, ['editions']);
          this.photoUrl = environment.serverUri + '/' + res.data.photo;
          this.form.controls.editions = this.fb.array([]);
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
    this.goTo('/admin/library/books');
  }

  getData() {
    const requests = [
      this.publisherHttpService.list(),
      this.authorHttpService.list(),
      this.commonHttpService.getLanguages(),
      this.subjectHttpService.list()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.publishers = res[0].data.items;
        this.authors = res[1].data.items;
        this.languages = res[2].data.items;
        this.subjects = res[3].data.items;
      }
    );
  }

  async fileChanged(e, control: any) {
    await this.fileChangedInternal(e, control, 'eBook');
  }

  async fileChanged2(e, control: any) {
    await this.fileChangedInternal(e, control, 'eBook2');
  }

  async fileChangedInternal(e, control: any, controlName: string) {
    this.log('edition file changed', e, control);
    const file = e.target.files[0];
    let messageId
    if (file) {
      const txt = await this.t('file.uploading');
      messageId = this._messageService.loading(txt).messageId;
      var fr = new FileReader();
      fr.onload = () => {
        this.photoUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          console.log('progress', progress);
        },
        success => {
          control.controls[controlName].setValue(success.data);
          this._messageService.remove(messageId);
        },
        error => {
          this._messageService.remove(messageId);
        }
      );
    }
  }

  addEdition() {
    this.createEditionFormGroup({});
  }

  deleteEdition(index) {
    const editionFormArray = this.getEditionFormArray();
    if (editionFormArray.controls && editionFormArray.controls.length) {
      editionFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.editions?.length) {
      res.data.editions.forEach(x => {
        this.createEditionFormGroup(x);
      });
    }
  }

  private createEditionFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      publicationDate: [null, [], this.v.required.bind(this)],
      numberOfPage: [null, [], this.v.required.bind(this)],
      edition: [null, [], this.v.required.bind(this)],
      hasEbook: [],
      eBook: [],
      eBook2: [],
      eBookName: [],
      eBook2Name: [],
      isEbookDownloadable: [],
      ebookFormat: []
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const editionFormArray = this.getEditionFormArray();
    editionFormArray.push(formGroup);
    if (data.eBook) {
      formGroup.controls.hasEbook.setValue(true);
      formGroup.controls.isEbookDownloadable.setValue(data.eBook.isDownloadable);
      formGroup.controls.eBook.setValue(data.eBook.eBook);
      formGroup.controls.eBookName.setValue(data.eBook.fileName);
      formGroup.controls.eBook2.setValue(data.eBook.eBook2);
      formGroup.controls.eBook2Name.setValue(data.eBook.fileName2);
    }
  }

  private getEditionFormArray(): FormArray {
    return this.form.get("editions") as FormArray;
  }


}