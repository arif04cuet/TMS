import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-requisition-view',
  templateUrl: './requisition-view.component.html'
})
export class RequisitionViewComponent extends BaseComponent {

  loading: boolean = true;
  statuses = [];
  items = [];
  typeText = {};
  data: any = {};
  loggedInUserRoleId;

  private requisitionId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private requisitionHttpService: RequisitionHttpService
  ) {
    super();
  }

  ngOnInit() {
    this.requisitionId = this.activatedRoute.snapshot.params.id;
    this.get(this.requisitionId);
    this.typeText = {
      1: 'Asset',
      3: 'Consumable',
      6: 'License'
    };
  }

  submit(status: number): void {
    this.loading = true;
    const _items = JSON.parse(JSON.stringify(this.items));
    const items = _items.map(x => {
      const type = x.type;
      x.type = type.id;
      return x;
    });
    const body: any = {
      requisition: Number(this.requisitionId),
      status: status,
      items: items
    };
    this.subscribe(this.requisitionHttpService.submit(body),
      res => {
        this.success('success');
        this.loading = false;
        this.cancel();
      },
      err => {
        this.loading = false;
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.requisitionHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          if (res.data.items) {
            this.items = res.data.items.map(x => {
              const obj = {
                id: x.id,
                asset: x.asset.id,
                name: x.asset.name,
                type: { id: x.assetType.id, name: this.typeText[x.assetType.id] },
                quantity: x.quantity,
                comment: x.comment,
                available: x.available
              };
              return obj;
            })
          }
          if (res.data.histories) {
            res.data.histories.forEach(item => {
              if (item.approver) {
                item.approverName = item.approver.name;
              }
              else if (item.roleApprover) {
                item.approverName = item.roleApprover.name;
              }
            });
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
    this.goTo('/admin/asset/my-requisitions');
  }

  quantityChanged(e, data) {
    if (data.quantity > data.available) {
      this.info('quantity.exceeds');
      setTimeout(() => data.quantity = data.available);
    }
    if (data.quantity <= 0) {
      setTimeout(() => data.quantity = 1);
    }
  }

}
