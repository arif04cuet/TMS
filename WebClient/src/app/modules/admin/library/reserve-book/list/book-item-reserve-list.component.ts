import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { IButton } from 'src/app/shared/table-actions.component';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-book-item-reserve-list',
  templateUrl: './book-item-reserve-list.component.html'
})
export class BookItemReserveListComponent extends TableComponent {

  @Searchable("BookItem.Barcode", "like") bookBarCode;

  buttons: IButton[] = [
    {
      label: 'issue',
      action: d => this.issue(d),
      condition: d => !d.issuedTo && d.status.id == 5,
      permissions: ['book.reservation.manage', 'book.issue'],
      type: 'primary'
    },
    {
      label: 'cancel',
      action: d => this.cancel(d),
      condition: d => d.status && d.status.id == 5, // none
      //permissions: ['book.reservation.manage', 'book.reservation.return'],
      type: 'primary',
      // icon: 'close-circle'
    },
    // {
    //   label: 'edit',
    //   condition: d => d.status && d.status.id == 5,
    //   action: d => this.add(d),
    //   permissions: ['book.reservation.manage', 'book.reservation.update'],
    //   icon: 'edit'
    // },
    // {
    //   label: 'delete',
    //   action: d => this.delete(d),
    //   condition: d => d.status && d.status.id == 5,
    //   permissions: ['book.reservation.manage', 'book.reservation.delete'],
    //   icon: 'delete'
    // }
  ]

  constructor(
    private bookReservationHttpService: BookReservationHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bookReservationHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/books/reservations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/books/reservations/add');
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

  cancel(data) {
    if (data && data.id) {
      this.loading = true;
      this.subscribe(this.bookReservationHttpService.cancel(data.id),
        res => {
          this.loading = false;
          this.refresh();
        },
        err => this.loading = false
      );
    }
  }

  issue(data) {
    if (data && data.id) {
      this.loading = true;
      this.subscribe(this.bookReservationHttpService.issue(data.id),
        res => {
          this.loading = false;
          this.refresh();
        },
        err => this.loading = false
      );
    }
  }

}
