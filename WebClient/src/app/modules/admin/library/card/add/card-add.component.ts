import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { forkJoin, of } from 'rxjs';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { FormControl } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-library-card-add',
  templateUrl: './card-add.component.html'
})
export class CardAddComponent extends FormComponent {

  loading: boolean = true;
  cardTypes = [];
  photoUrl;

  @ViewChild('statusSelect') statusSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private libraryCardHttpService: LibraryCardHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      numberOfCopy: [null, [], this.numberOfCopyValidation.bind(this)],
      cardType: [null, [], this.v.required.bind(this)],
      cardFee: [null, [], this.v.required.bind(this)],
      lateFee: [null, [], this.v.required.bind(this)],
      maxIssueCount: [null, [], this.v.required.bind(this)],
      statusId: [null, [], this.v.required.bind(this)],
      photoId: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
    this.getData();
  }

  ngAfterViewInit() {
    this.statusSelect.register((pagination, search) => {
      return this.libraryCardHttpService.listStatus(pagination, search);
    });
    if(this.isAddMode()) {
      this.statusSelect.selectFirstOption();
    }
    this.statusSelect.fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.libraryCardHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.libraryCardHttpService.edit(this.id, body),
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
      this.subscribe(this.libraryCardHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.setValue('cardType', res.data.cardType?.id);
          this.setValue('statusId', res.data.status?.id)
          this.photoUrl = environment.serverUri + '/' + res.data.photo;
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  getData() {
    const requests = [
      this.libraryCardHttpService.listTypes()
    ]
    this.subscribe(forkJoin(requests),
      (res: any) => {
        this.cardTypes = res[0].data.items;
      }
    );
  }

  cancel() {
    this.goTo('/admin/library/cards');
  }

  numberOfCopyValidation(control: FormControl) {
    if (this.isAddMode() && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

}
