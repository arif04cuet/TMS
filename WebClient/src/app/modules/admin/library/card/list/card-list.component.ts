import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { IButton } from 'src/app/shared/table-actions.component';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { forkJoin } from 'rxjs';
declare const JsBarcode: any;

@Component({
  selector: 'app-library-card-list',
  templateUrl: './card-list.component.html'
})
export class CardListComponent extends TableComponent {

  types = [];

  @Searchable("Barcode", "like") number;
  @Searchable("CardTypeId", "eq") type;
  buttons: IButton[] = [
    {
      label: 'print',
      action: d => this.print(d),
      // permissions: ['card.manage', 'card.update'],
      icon: 'edit',
      condition: d => d.member != null
    },
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['card.manage', 'card.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['card.manage', 'card.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private libraryCardHttpService: LibraryCardHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryCardHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.loadCardTypes();
  }

  loadCardTypes() {

    this.loading = true;
    const request = [
      this.libraryCardHttpService.listTypes(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.types = res[0].data.items;
      }
    );

  }


  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/cards/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/cards/add');
    }
  }

  print(model) {
    const oldCard = document.getElementById('library-card');
    if (oldCard) {
      oldCard.remove();
    }

    let data = "";
    let photo = model.member?.photo ? environment.serverUri + '/' + model.member.photo : './assets/images/userphoto.png';
    photo = photo + '?rand=' + Math.floor(Math.random() * 1000);
    const title = this._translate.instant('library.card.print.title');
    const address = this._translate.instant('library.card.print.address');
    const expireDate = model.expireDate ? moment.utc(model.expireDate).local().format('MMM D, YYYY') : "";
    const issueDate = model.issueDate ? moment.utc(model.issueDate).local().format('MMM D, YYYY') : "";

    const labelTitle = this._translate.instant('library.card.print.label.title');
    const labelCode = this._translate.instant('library.card.print.label.code');
    const labelIssueDate = this._translate.instant('library.card.print.label.issue_date');
    const labelExpDate = this._translate.instant('library.card.print.label.exp_date');

    data += `
      <div class="card-container">
        <div class="top">
            <div class="logo">
                <img src="./assets/images/logo.jpg" alt="logo">
            </div>
            <div class="address">
                <div class="title">${title}</div>
                <div>${address}</div>
            </div>
        </div>
        <div class="bottom">
            <div class="photo">
                <img src="${photo}" alt="photo">
                <svg id="barcode-${model.barcode}"></svg>
            </div>
            <div class="details">
                <div class="name">${model.member.name}</div>
                <div class="details-line">
                    <div class="label">পদবী</div>
                    <div class="value">${model.member.designation}</div>
                </div>
                <div class="details-line">
                    <div class="label">বারকোড</div>
                    <div class="value">${model.barcode}</div>
                </div>
                <div class="two-col">
                    <div class="details-line first-line">
                        <div class="label">ইস্যু তারিখ</div>
                        <div class="value">${issueDate}</div>
                    </div>
                    <div class="details-line">
                        <div class="label">মেয়াদ উত্তীর্ণের তারিখ</div>
                        <div class="value">${expireDate}</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="bottom-line"></div>
      </div>`;
    const div = document.createElement('div');
    div.setAttribute('id', 'library-card');
    div.innerHTML = data;
    document.getElementsByTagName('html')[0].appendChild(div);
    JsBarcode(`#barcode-${model.barcode}`, model.barcode, { width: 1, height: 20, fontSize: '5px', displayValue: false });

    setTimeout(function () {
      window.print();
    }, 250);

  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

}
