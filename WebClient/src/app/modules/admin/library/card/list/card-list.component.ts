import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';
import { IButton } from 'src/app/shared/table-actions.component';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';

@Component({
  selector: 'app-library-card-list',
  templateUrl: './card-list.component.html'
})
export class CardListComponent extends TableComponent {

  @Searchable("Barcode", "like") number;
  @Searchable("CardType.Name", "like") type;
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
    const photo = model.member ? environment.serverUri + '/' + model.member.photo : '/src/assets/images/userphoto.png';
    const title = this._translate.instant('library.card.print.title');
    const address = this._translate.instant('library.card.print.address');
    const expireDate = model.expireDate ? moment.utc(model.expireDate).local().format('MMM D, YYYY') : "";
    const issueDate = model.issueDate ? moment.utc(model.issueDate).local().format('MMM D, YYYY') : "";
    data += `
      <div class="card-container">
        <div class="top">
            <div class="logo">
                <img src="http://localhost:4400/assets/images/logo.jpg" alt="logo">
            </div>
            <div class="address">
                <div class="title">${title}</div>
                <div>${address}</div>
            </div>
        </div>
        <div class="bottom">
            <div class="photo">
                <img src="${photo}" alt="photo">
            </div>
            <div class="details">
                <div class="name">${model.member.name}</div>
                <div class="details-line">
                    <div class="label">Title</div>
                    <div class="value">${model.member.designation}</div>
                </div>
                <div class="details-line">
                    <div class="label">Code</div>
                    <div class="value">${model.barcode}</div>
                </div>
                <div class="two-col">
                    <div class="details-line first-line">
                        <div class="label">Issue Date</div>
                        <div class="value">${issueDate}</div>
                    </div>
                    <div class="details-line">
                        <div class="label">Exp Date</div>
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
    window.print();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

}
