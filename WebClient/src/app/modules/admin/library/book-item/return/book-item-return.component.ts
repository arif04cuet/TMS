import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@Component({
  selector: 'app-book-item-return',
  templateUrl: './book-item-return.component.html'
})
export class BookItemReturnComponent extends FormComponent {

  loading: boolean = true;

  members = [];
  cards = [];
  data: any = <any>{};

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      bookItem: [],
      actualReturnDate: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.bookHttpService.returnBookItem(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.bookHttpService.returnBookItem(this.id, body),
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
      this.subscribe(this.bookHttpService.getBookItemIssue(id),
        (res: any) => {
          this.data = res.data;
          this.setValue('bookItem', res.data.bookItem?.id);
          this.loading = false;
        },
        err => {
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/books/items');
  }

  getData() {
    const requests = [
      this.libraryMemberHttpService.list()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.members = res[0].data.items;
      }
    );
  }

  onMemberChange(e) {
    this.subscribe(this.libraryMemberHttpService.cards(e),
      (res: any) => {
        this.cards = res.data.items;
      }
    );
  }

}