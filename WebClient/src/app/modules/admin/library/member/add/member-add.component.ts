import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormArray, AbstractControl, FormGroup } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { forEachObj } from 'src/services/utilities.service';

@Component({
  selector: 'app-member-add',
  templateUrl: './member-add.component.html'
})
export class MemberAddComponent extends FormComponent {

  loading: boolean = true;
  libraries = [];
  statuses = [];
  cardStatuses = [];
  cards = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private commonHttpService: CommonHttpService,
    private libraryHttpService: LibraryHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private libraryCardHttpService: LibraryCardHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      mobile: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.password.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      library: [null, [], this.v.required.bind(this)],
      memberSince: [null, [], this.v.required.bind(this)],
      card: this.fb.array([
        this.fb.group({
          number: [null, [], this.v.required.bind(this)],
          card: [null, [], this.v.required.bind(this)],
          status: [null, [], this.v.required.bind(this)],
          expireDate: [null, [], this.v.required.bind(this)]
        })
      ]),
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    body.card = body.card[0];
    this.submitForm(
      {
        request: this.libraryMemberHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.libraryMemberHttpService.edit(this.id, body),
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
      this.subscribe(this.libraryMemberHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ["card"]);
          this.setValues(this.getCardControls(), res.data.card);
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.status.setValue(1);
      this.getCardControls().status.setValue(1);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/members');
  }

  getData() {
    const requests = [
      this.commonHttpService.getStatusList(),
      this.libraryHttpService.list(),
      this.libraryCardHttpService.list(),
      this.libraryCardHttpService.listStatus(),
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.statuses = res[0].data.items;
        this.libraries = res[1].data.items;
        this.cards = res[2].data.items;
        this.cardStatuses = res[3].data.items;
      }
    );
  }

  private password(control: FormControl) {
    if (this.mode == 'add' || control.value) {
      if (!control.value) {
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
      else if (control.value.length < 4) {
        return this.error(MESSAGE_KEY.MUST_BE_EQUAL_OR_GREATER_THAN_4_CHARACTERS);
      }
    }
    return of(true);
  }

  private getCardFormArray(): FormArray {
    return this.form.get("card") as FormArray;
  }

  private getCardControls(): {
    [key: string]: AbstractControl;
  } {
    const formGroup = this.getCardFormArray().controls[0] as FormGroup
    return formGroup.controls;
  }

}
