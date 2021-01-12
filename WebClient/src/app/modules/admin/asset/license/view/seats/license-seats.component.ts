import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';

@Component({
  selector: 'app-license-seats',
  templateUrl: './license-seats.component.html'
})
export class LicenseSeatsComponent extends BaseComponent {

  loading: boolean = true;
  item;
  licenseId: number;
  firstAvailableItem;

  constructor(
    private activatedRoute: ActivatedRoute,
    private licenseHttpService: LicenseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot

    const id = this.getQueryParams('id');

    this.get(id);

  }

  get(id) {

    this.loading = true;

    this.subscribe(this.licenseHttpService.getDetails(id),
      (res: any) => {

        this.firstAvailableItem = res.data.seatList.find(x => !(x.issuedToUserId || x.issuedToAsset));
        this.item = res.data;
        this.licenseId = res.data.id;
        this.loading = false;
        console.log(this.firstAvailableItem);
      }
    );


  }

  checkout(licenseSeatId) {

    if (licenseSeatId != this.firstAvailableItem.id) {
      const message = this._translate.instant('license_cant_issue_random_order', { x0: this.firstAvailableItem.name });
      this.failed(message);
      return false;
    }

    this.goTo(`/admin/asset/licenses/${this.licenseId}/checkout?checkout=${licenseSeatId}`);
  }

  checkin(licenseSeatId) {
    this.goTo(`/admin/asset/licenses/${this.licenseId}/checkin?checkin=${licenseSeatId}`);
  }

  delete(licenseSeatId) {

    let lastAvailableItem = this.item.seatList.filter(x => !(x.issuedToUserId || x.issuedToAsset)).pop();


    if (licenseSeatId != lastAvailableItem.id) {
      const message = this._translate.instant('license_cant_delete_random_order', { x0: lastAvailableItem.name });
      this.failed(message);
      return false;
    }

    // delete item from db
    this.deleteItem(licenseSeatId);
  }

  async deleteItem(licenseSeatId) {
    const deletedText = await this.t('successfully.deleted')
    const deleteModal = this._modalService.confirm({
      nzTitle: await this.t('confirm'),
      nzContent: await this.t('do.you.want.to.delete'),
      nzOkText: await this.t('delete'),
      nzCancelText: await this.t('cancel'),
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;

        this.subscribe(this.licenseHttpService.deleteSeat(licenseSeatId),
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this._messageService.create('success', deletedText);
            this.item.seatList.splice(-1, 1);
          },
          err => {
            deleteModal.getInstance().nzOkLoading = false;

          }
        );
      }
    });


  }

  cancel() {
    this.goTo('/admin/asset/licenses');
  }

  seatName(value) {

    return this.splitTranslate(value);
  }

}
