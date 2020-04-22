import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-library-card-add',
  templateUrl: './card-add.component.html'
})
export class CardAddComponent extends FormComponent {

  loading: boolean = true;
  cardTypes = [];

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
      name: [null, [], this.v.required.bind(this)],
      cardType: [null, [], this.v.required.bind(this)],
      fees: [null, [], this.v.required.bind(this)],
      maxIssueCount: [null, [], this.v.required.bind(this)],
      expireDate: [null, [], this.v.required.bind(this)],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
    this.getData();
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

}
