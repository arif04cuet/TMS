import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-book-item-issue',
  templateUrl: './book-item-issue.component.html'
})
export class BookItemIssueComponent extends FormComponent {

  loading: boolean = false;

  @ViewChild('cardSelect') cardSelect: SelectControlComponent;
  @ViewChild('bookItemSelect') bookItemSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      book: [],
      bookItem: [],
      issueDate: [null, [], this.v.required.bind(this)],
      returnDate: [null, [], this.v.required.bind(this)],
      card: [null, [], this.v.required.bind(this)],
      note: [],
      sendEmail: [true]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
    this.setValue('issueDate', new Date());
  }

  ngAfterViewInit() {

    this.cardSelect.register((pagination, search) => {
      return this.libraryMemberHttpService.cards(pagination, search);
    }).fetch();

    this.bookItemSelect.register((pagination, search) => {
      return this.bookHttpService.listBookItems(pagination, search);
    })
      .onLoadCompleted(() => {
        if(this.id) {
          this.bookItemSelect.setValue(Number(this.id));
        }
      })
      .fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.submitting = true;
      this.subscribe(this.bookHttpService.issueBookItem(this.id, body),
        (res: any) => {
          this.submitting = false;
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        },
        err => {
          this.submitting = false;
        }
      );
    });
  }

  get(id) {
    if (id) {
      this.setValue('bookItem', Number(id));
    }
  }

  cancel() {
    this.goTo('/admin/library/books/items');
  }

  getValidReturnDate = (d: Date) => {
    const r = d.getTime() < this.form.controls.issueDate.value.getTime();
    return r;
  }

  bookInfo = (e) => {
    return `${e.title} by ${e.author.name}`;
  };

  cardInfo = (e) => {
    const info = this.t('card.holder.name.is.x0', { x0: e.member });
    return info;
  };

}