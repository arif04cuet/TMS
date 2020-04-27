import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/book-http.service';
import { FormControl } from '@angular/forms';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-book-item-add',
  templateUrl: './book-item-add.component.html'
})
export class BookItemAddComponent extends FormComponent {

  loading: boolean = true;

  @ViewChild('statusSelect') statusSelect: SelectControlComponent;
  @ViewChild('formatSelect') formatSelect: SelectControlComponent;
  @ViewChild('bookSelect') bookSelect: SelectControlComponent;
  @ViewChild('editionSelect') editionSelect: SelectControlComponent;
  @ViewChild('librarySelect') librarySelect: SelectControlComponent;
  @ViewChild('rackSelect') rackSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookHttpService: BookHttpService,
    private rackHttpService: RackHttpService,
    private libraryHttpService: LibraryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      book: [null, [], this.v.required.bind(this)],
      library: [null, [], this.v.required.bind(this)],
      edition: [null, [], this.v.required.bind(this)],
      rack: [null, [], this.v.required.bind(this)],
      purchasePrice: [null, [], this.v.required.bind(this)],
      dateOfPurchase: [null, [], this.v.required.bind(this)],
      numberOfCopy: [null, [], this.numberOfCopyValidator.bind(this)],
      format: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.statusSelect.register((pagination, search) => {
      return this.bookHttpService.listBookStatus(pagination, search);
    }).fetch();

    this.formatSelect.register((pagination, search) => {
      return this.bookHttpService.listBookFormats(pagination, search);
    }).fetch();

    this.bookSelect.register((pagination, search) => {
      return this.bookHttpService.list(pagination, search);
    }).fetch();

    this.librarySelect.register((pagination, search) => {
      return this.libraryHttpService.list(pagination, search);
    }).selectFirstOption().fetch();
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
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.setValue('status', 1);
      this.setValue('numberOfCopy', 1);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/books/items');
  }

  onBookChange(e) {
    if (e) {
      this.editionSelect.register((pagination, search) => {
        return this.bookHttpService.getEditions(e, pagination, search);
      }).fetch();
    }
  }

  onLibraryChange(e) {
    if (e) {
      this.rackSelect.register((pagination, search) => {
        return this.rackHttpService.listLibraryRacks(e, pagination, search);
      }).fetch();
    }
  }

  private numberOfCopyValidator(control: FormControl) {
    const v = control.value;
    if (v === undefined || v === null) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (Number(v) < 1) {
      return this.error('must.be.greater.than.x0', { x0: 1 });
    }
    return of(true);
  }


}