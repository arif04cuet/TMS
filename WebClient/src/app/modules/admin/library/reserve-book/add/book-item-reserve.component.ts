import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-book-item-reserve-add',
  templateUrl: './book-item-reserve.component.html'
})
export class BookItemReserveAddComponent extends FormComponent {

  loading: boolean = true;

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild('bookSelect') bookSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private bookReservationHttpService: BookReservationHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      bookItem: [null, [], this.v.required.bind(this)],
      user: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.bookSelect.register((pagination, search) => {
      return this.bookReservationHttpService.assignableBookItems(pagination, search);
    }).fetch();

    this.userSelect.register((pagination, search) => {
      return this.libraryMemberHttpService.list(pagination, search).pipe(

        map((x: any) => {

          var items = x.data.items.filter(item => item.card !== null);

          x.data.items = items;

          return x;

        })

      );
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.bookReservationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.bookReservationHttpService.edit(this.id, body),
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
      this.subscribe(this.bookReservationHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.setValue('bookItem', res.data.bookItemId);
          this.setValue('user', res.data.user.id);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/library/books/reservations');
  }

}