import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { of, forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@Component({
  selector: 'app-member-add-existing',
  templateUrl: './member-add.component.html'
})
export class MemberAddComponent extends FormComponent {

  loading: boolean = true;
  libraries = [];
  users = []
  cards = []

  constructor(
    private activatedRoute: ActivatedRoute,
    private userHttpService: UserHttpService,
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
      library: [null, [], this.v.required.bind(this)],
      user: [null, [], this.v.required.bind(this)],
      memberSince: [null, [], this.v.required.bind(this)],
      cardId: [null, [], this.v.required.bind(this)],
      cardExpireDate: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.libraryMemberHttpService.addExisting(body),
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
          this.setValues(this.form.controls, res.data);
          const card = res.data.card;
          if(card) {
            this.setValue('cardId', card.id);
            this.setValue('cardExpireDate', card.expireDate);
          }
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/members');
  }

  getData() {
    const requests = [
      this.userHttpService.list(),
      this.libraryHttpService.list(),
      this.libraryCardHttpService.listAssignableCards(),
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.users = res[0].data.items;
        this.libraries = res[1].data.items;
        this.cards = res[2].data.items;
        if (this.libraries.length > 0) {
          this.form.controls.library.setValue(this.libraries[0].id);
        }
      }
    );
  }

}
