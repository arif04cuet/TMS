import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/book-http.service';
import { AuthorHttpService } from 'src/services/http/author-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { SubjectHttpService } from 'src/services/http/subject-http.service';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.scss']
})
export class BookAddComponent extends FormComponent {

  loading: boolean = true;
  users = [];
  languages = [];
  publishers = [];
  authors = [];
  subjects = [];

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private authorHttpService: AuthorHttpService,
    private publisherHttpService: PublisherHttpService,
    private commonHttpService: CommonHttpService,
    private subjectHttpService: SubjectHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      title: [null, [], this.v.required.bind(this)],
      language: [],
      publisher: [],
      subjects: [],
      author: [],
      editions: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
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
          this.setValues(this.form.controls, res.data, ['editions']);
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

  optionChanged(e) {

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
      publicationDate: [null, [], this.v.required.bind(this)],
      numberOfPage: [null, [], this.v.required.bind(this)],
      // numberOfCopy: [null, [], this.v.required.bind(this)],
      edition: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const editionFormArray = this.getEditionFormArray();
    editionFormArray.push(formGroup);
  }

  private getEditionFormArray(): FormArray {
    return this.form.get("editions") as FormArray;
  }


}