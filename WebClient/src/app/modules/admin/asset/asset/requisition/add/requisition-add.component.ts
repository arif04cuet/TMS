import { Component, ViewChild, Type, TemplateRef } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { AssetModalComponent } from '../asset-modal/asset-modal.component';
import { NzModalService, NzModalRef } from 'ng-zorro-antd';

@Component({
  selector: 'app-requisition-add',
  templateUrl: './requisition-add.component.html'
})
export class RequisitionAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];
  assetModalInfo: any = {};
  items = [];
  data: any = {};

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild('batchSelect') batchSelect: SelectControlComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;

  typeText = {};

  private modal: NzModalRef<AssetModalComponent>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private requisitionHttpService: RequisitionHttpService,
    private userHttpService: UserHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private v: CommonValidator,
    private modalService: NzModalService
  ) {
    super();
  }

  async ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      title: [null, [], this.v.required.bind(this)],
      currentApprover: [],
      batchSchedule: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
    this.typeText = {
      1: await this.t('asset'),
      3: await this.t('consumable'),
      6: await this.t('license')
    };
  }

  ngAfterViewInit() {

    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.batchSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);

    if (this.items.filter(x => x.quantity <= 0).length > 0) {
      this.info('quantity.can.not.be.zero');
      return
    }

    const items = JSON.parse(JSON.stringify(this.items));
    body.items = items.map(x => {
      const type = x.type;
      x.type = type.id;
      return x;
    })

    this.submitForm(
      {
        request: this.requisitionHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        },
        failed: res => {
          if (res.error
            && res.error.message == "form_error"
            && res.error.data.length) {
            this._messageService.error(res.error.data[0].message);
          }
        }
      },
      {
        request: this.requisitionHttpService.edit(this.id, body),
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
      this.subscribe(this.requisitionHttpService.get(id),
        (res: any) => {
          if (res.data.items) {
            this.data = res.data;
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

              if (x.assetType.id == 1) {
                if (!this.assetModalInfo.assets) {
                  this.assetModalInfo.assets = [];
                }
                this.assetModalInfo.assets.push({ id: x.asset.id });
              }

              if (x.assetType.id == 3) {
                if (!this.assetModalInfo.consumables) {
                  this.assetModalInfo.consumables = [];
                }
                this.assetModalInfo.consumables.push({ id: x.asset.id });
              }

              if (x.assetType.id == 6) {
                if (!this.assetModalInfo.licenses) {
                  this.assetModalInfo.licenses = [];
                }
                this.assetModalInfo.licenses.push({ id: x.asset.id });
              }

              return obj;

            })
          }
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      //this.form.controls.isActive.setValue(true);
      this.loading = false;

    }
  }

  cancel() {
    this.goTo('/admin/asset/my-requisitions');
  }

  quantityChanged(e, data) {
    if (data.quantity > data.available) {
      //this.info('quantity.exceeds');
      //setTimeout(() => data.quantity = data.available);
    }
    if (data.quantity <= 0) {
      //setTimeout(() => data.quantity = 1);
    }
  }

  addAsset() {
    const modal = this.createModal(AssetModalComponent);
    this.modal = modal;
    this.subscribe(modal.afterClose, res => {
      const component = modal.getContentComponent();
      this.assetModalInfo = component.data;
      const send = component.send;
      component.send = false;
      if (this.assetModalInfo && send) {
        const items = [];
        items.push(...this.makeItems(this.assetModalInfo.assets, 1));
        items.push(...this.makeItems(this.assetModalInfo.licenses, 6));
        items.push(...this.makeItems(this.assetModalInfo.consumables, 3, 'item'));
        this.items = items;
      }
    });
  }

  sendItemFromModal() {
    if (this.modal) {
      this.modal.getContentComponent().send = true;
      this.modal.triggerCancel();
    }
  }

  closeModal() {
    if (this.modal) {
      this.modal.triggerCancel();
    }
  }

  createModal<T>(component: Type<T>) {
    return this.modalService.create({
      nzWidth: '80%',
      nzContent: component,
      nzGetContainer: () => document.body,
      nzComponentParams: <any>{
        data: this.assetModalInfo
      },
      nzFooter: this.modalFooter
    });
  }

  deleteItem(index, data) {
    this.items.splice(index, 1);
    this.items = [...this.items];
    if (this.assetModalInfo) {
      if (this.assetModalInfo.assets && data.type.id == 1) {
        this.assetModalInfo.assets = this.assetModalInfo.assets.filter(x => x.id != data.asset);
      }
      if (this.assetModalInfo.licenses && data.type.id == 6) {
        this.assetModalInfo.licenses = this.assetModalInfo.licenses.filter(x => x.id != data.asset);
      }
      if (this.assetModalInfo.consumables && data.type.id == 3) {
        this.assetModalInfo.consumables = this.assetModalInfo.consumables.filter(x => x.id != data.asset);
      }
    }
  }

  private makeItems(items: any[], type: number, nameProp: string = 'name') {
    if (items && items.length) {
      const _items = [];
      items.forEach(item => {
        const oldItem = this.items.find(x => x.asset == item.id && x.type.id == type);
        _items.push({
          asset: item.id,
          name: item[nameProp],
          type: { id: type, name: this.typeText[type] },
          quantity: type == 1 ? 1 : (oldItem?.quantity || 0),
          comment: oldItem?.comment || '',
          available: item.available
        })
      });
      return _items;
    }
    return []
  }

}
