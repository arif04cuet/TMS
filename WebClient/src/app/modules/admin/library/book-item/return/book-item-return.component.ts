import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-book-item-return',
  templateUrl: './book-item-return.component.html'
})
export class BookItemReturnComponent extends FormComponent {

  loading: boolean = true;

  members = [];
  cards = [];
  data: any = <any>{};
  fine;
  dateTitle;

  private checkFine = true;

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      bookItem: [],
      actualReturnDate: [new Date(), [], this.v.required.bind(this)],
      nextReturnDate: [null, [], this.nextReturnDateValidation.bind(this)],
      returnOrRenew: ['return'],
      payFine: [true],
      fineAmount: [null, [], this.fineAmountValidation.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

    await this.updateTitle();
    this.checkFineRequest();
  }

  submit(): void {

    // check fine
    const date = this.form.controls.actualReturnDate.value
    const valid = this.validateForm();
    if (!valid && (date === null || date === undefined))
      return;

    if (this.checkFine) {
      this.checkFineRequest(() => {
        this._submit();
      });
    }
    else {
      this._submit();
    }
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

  isReturn() {
    return this.form.controls.returnOrRenew.value === "return";
  }

  isRenew() {
    return this.form.controls.returnOrRenew.value === "renew";
  }

  dateChange(e) {
    this.checkFine = true;
    this.checkFineRequest();
  }

  async updateTitle() {
    if (this.isReturn()) {
      this.submitButtonText = await this.t('return');
      this.dateTitle = await this.t('actual.return.date');
    }
    else if (this.isRenew()) {
      this.submitButtonText = await this.t('renew');
      this.dateTitle = await this.t('return.date');
    }
  }

  async returnOrRenewChange(e) {
    await this.updateTitle();
  }

  private checkFineRequest(onNoFine?: () => void) {
    const fineBody = {
      actualReturnDate: this.form.controls.actualReturnDate.value
    }
    this.subscribe(this.bookHttpService.checkFine(this.id, fineBody),
      (res: any) => {
        if (res.data !== null && res.data !== undefined) {
          // fined
          this.fine = res.data;
          this.checkFine = false;
          this.loading = false;
          this.form.controls.fineAmount.setValue(this.fine.fineAmount);
        }
        else {
          this.invoke(onNoFine);
        }
      },
      err => {
        this.loading = false;
      }
    );
  }

  private _submit() {
    const body: any = this.constructObject(this.form.controls);
    const fineAmount = this.form.controls.fineAmount.value
    if (fineAmount && this.fine && this.form.controls.payFine) {
      const fineBody = {
        amount: this.form.controls.fineAmount.value
      }
      body.fine = fineBody;
    }
    body.actualReturnDate = this.form.controls.actualReturnDate.value;
    body.nextReturnDate = this.form.controls.nextReturnDate.value;
    body.isRenew = this.isRenew();
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

  private fineAmountValidation(control: FormControl) {
    if (this.fine && this.form.controls.payFine.value) {
      const v = control.value;
      if (v === null || v === undefined) {
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
      else if (v <= 0) {
        return this.error('value.can.not.negative');
      }
      else if (v > this.fine.fineAmount) {
        return this.error('amount.exceeds');
      }
    }
    return of(false);
  }

  private nextReturnDateValidation(control: FormControl) {
    if (this.form && this.isRenew()) {
      const v = control.value;
      if (!v) {
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
    }
    return of(false);
  }

}