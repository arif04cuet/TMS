import { Component, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { environment } from 'src/environments/environment';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { DepreciationHttpService } from 'src/services/http/asset/depreciation-http.service';

@Component({
  selector: 'app-asset-add',
  templateUrl: './asset-add.component.html',
  styleUrls: ['./asset-add.component.scss']
})
export class AssetAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;
  
  @ViewChildren('modelSelect') modelSelects: QueryList<SelectControlComponent>;
  @ViewChildren('statusSelect') statusSelects: QueryList<SelectControlComponent>;
  @ViewChildren('depreciationSelect') depreciationSelects: QueryList<SelectControlComponent>;

  photoUrl;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetHttpService: AssetBaseHttpService,
    private assetModelHttpService: AssetModelHttpService,
    private depreciationHttpService: DepreciationHttpService,
    private statusHttpService: StatusHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      supplier: [],
      location: [],
      note: [],
      orderNo: [],
      invoiceNo: [],
      invoiceDate: [null, [], this.v.required.bind(this)],
      inventoryEntryDate: [null, [], this.v.required.bind(this)],
      purchaseDate: [null, [], this.v.required.bind(this)],
      items: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.locationSelect.register((pagination, search) => {
      return this.assetHttpService.locations(pagination, search);
    }).fetch();

    this.supplierSelect.register((pagination, search) => {
      return this.assetHttpService.suppliers(pagination, search);
    }).fetch();

    this.subscribe(this.modelSelects.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.last.register((pagination, search) => {
        return this.assetModelHttpService.list(pagination, search);
      }).fetch();
    });

    this.subscribe(this.statusSelects.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.last.register((pagination, search) => {
        return this.statusHttpService.list(pagination, search);
      }).fetch();
    });

    this.subscribe(this.depreciationSelects.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.last.register((pagination, search) => {
        return this.depreciationHttpService.list(pagination, search);
      }).fetch();
    });

  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (this.id) {
      body.id = Number(this.id);
    }
    const items = (this.form.controls.items as any).controls.length;
    if (!items || items <= 0) {
      this.info('please.add.at.least.one.item');
      return;
    }
    this.submitForm(
      {
        request: this.assetHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        },
        failed: res => {
          if (res.error
            && res.error.message == "form_error"
            && res.error.data.length
            && res.error.data[0].field == "Items") {
            this._messageService.error(res.error.data[0].message);
          }
        }
      },
      {
        request: this.assetHttpService.edit(this.id, body),
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
      this.subscribe(this.assetHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ['items']);
          this.form.controls.items = this.fb.array([]);
          this.prepareForm(res);
          this.photoUrl = environment.serverUri + '/' + res.data.photo;
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
    this.goTo('/admin/asset');
  }

  addItem() {
    this.createItemFormGroup({});
  }

  deleteItem(index) {
    const itemFormArray = this.getItemFormArray();
    if (itemFormArray.controls && itemFormArray.controls.length) {
      itemFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.Items?.length) {
      res.data.Items.forEach(x => {
        this.createItemFormGroup(x);
      });
    }
  }

  private createItemFormGroup(data: any) {
    const formGroup = this.fb.group({
      assetTag: [null, [], this.v.required.bind(this)],
      itemNo: [],
      purchaseCost: [null, [], this.v.required.bind(this)],
      isRequestable: [false],
      warranty: [],
      maintenance: [],
      depreciation: [null, [], this.v.required.bind(this)],
      media: [],
      status: [null, [], this.v.required.bind(this)],
      assetModel: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const itemFormArray = this.getItemFormArray();
    itemFormArray.push(formGroup);
  }

  private getItemFormArray(): FormArray {
    return this.form.get("items") as FormArray;
  }

}
