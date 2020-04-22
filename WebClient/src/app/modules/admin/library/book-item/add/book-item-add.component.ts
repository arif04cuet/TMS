import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BookHttpService } from 'src/services/http/book-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray, FormControl } from '@angular/forms';
import { RackHttpService } from 'src/services/http/rack-http.service';

@Component({
  selector: 'app-book-item-add',
  templateUrl: './book-item-add.component.html',
  styleUrls: ['./book-item-add.component.scss']
})
export class BookItemAddComponent extends FormComponent {

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
      numberOfCopy: [null, [], this.numberOfCopyValidator.bind(this)],
      format: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
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
          this.form.controls.isbnAndBarcodes = this.fb.array([]);
          this.prepareForm(res);
          this.loading = false;
        }
      );
    }
    else {
      this.setValue('status', 1);
      this.setValue('numberOfCopy', 1);
      this.prepareForm(1);
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

  onChangeNumberOfCopy(e) {
    const number = Number(e.data);
    const controlLen = this.getIsbnAndBarcodeFormArray().length;
    if(number > controlLen) {
      const addLen = number - controlLen;
      for (let i = 0; i < addLen; i++) {
        this.createIsbnAndBarcodeFormGroup({});        
      }
    }
    else if (controlLen > number) {
      const subLen = controlLen - number;
      for (let i = 0; i < subLen; i++) {
        const index = controlLen - i - 1;
        this.getIsbnAndBarcodeFormArray().removeAt(index);
      }
    }
  }

  private prepareForm(numberOfCpoy) {
    for (let i = 0; i < numberOfCpoy; i++) {
      this.createIsbnAndBarcodeFormGroup({});
    }
  }

  private createIsbnAndBarcodeFormGroup(data: any) {
    const formGroup = this.fb.group({
      isbn: [null, [], this.v.required.bind(this)],
      barcode: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const isbnAndBarcodeFormArray = this.getIsbnAndBarcodeFormArray();
    isbnAndBarcodeFormArray.push(formGroup);
  }

  private getIsbnAndBarcodeFormArray(): FormArray {
    return this.form.get("isbnAndBarcodes") as FormArray;
  }

  private numberOfCopyValidator(control: FormControl) {
    const v = control.value;
    if (v === undefined || v === null) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (Number(v) < 1) {
      return this.error('must.be.greater.than.x0', {x0: 1});
    }
    return of(true);
  }


}