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

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.scss']
})
export class BookAddComponent extends FormComponent {

  loading: boolean = true;
  users = [];
  districts = [];
  languages = [];
  publishers = [];
  authors = [];

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private authorHttpService: AuthorHttpService,
    private publisherHttpService: PublisherHttpService,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      title: [null, [], this.v.required.bind(this)],
      isbn: [null, [], this.v.required.bind(this)],
      binding: [],
      language: [],
      publisher: [],
      author: [],
      district: []
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
          this.setValues(this.form.controls, res.data);
          this.form.controls.librarian.setValue(res.data.librarian?.id);
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
      this.commonHttpService.getLanguages()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.users = res[0].data.items;
      }
    );
  }

  optionChanged(e) {

  }

  addEdition() {

  }


}