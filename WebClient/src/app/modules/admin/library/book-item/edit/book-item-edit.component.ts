import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { RackHttpService } from 'src/services/http/rack-http.service';

@Component({
  selector: 'app-book-item-edit',
  templateUrl: './book-item-edit.component.html'
})
export class BookItemEditComponent extends FormComponent {

  loading: boolean = true;
  editionLoading: boolean = false;

  racks = [];
  books = [];
  formats = [];
  statuses = [];
  editions = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private commonHttpService: CommonHttpService,
    private rackHttpService: RackHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      book: [null, [], this.v.required.bind(this)],
      edition: [null, [], this.v.required.bind(this)],
      rack: [null, [], this.v.required.bind(this)],
      purchasePrice: [null, [], this.v.required.bind(this)],
      dateOfPurchase: [null, [], this.v.required.bind(this)],
      format: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      isbn: [null, [], this.v.required.bind(this)],
      barcode: [null, [], this.v.required.bind(this)],
      isbnAndBarcodes: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.bookHttpService.addBookItem(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.bookHttpService.editBookItem(this.id, body),
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
      this.subscribe(this.bookHttpService.getBookItem(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ['isbnAndBarcodes']);
          this.form.controls.editions = this.fb.array([]);
          this.onBookChange(res.data.book?.id);
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
      this.bookHttpService.listBookStatus(),
      this.bookHttpService.listBookFormats(),
      this.rackHttpService.list(),
      this.bookHttpService.list()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.statuses = res[0].data.items;
        this.formats = res[1].data.items;
        this.racks = res[2].data.items;
        this.books = res[3].data.items;
      }
    );
  }

  onBookChange(e) {
    this.editionLoading = true;
    this.subscribe(this.bookHttpService.getEditions(e),
      (res: any) => {
        this.editions = res.data.items;
        this.editionLoading = false;
      },
      err => {
        this.editionLoading = false;
      }
    );
  }

}