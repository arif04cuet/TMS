import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';

@Component({
  selector: 'app-asset-add',
  templateUrl: './asset-add.component.html'
})
export class AssetAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('statusSelect') statusSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;
  @ViewChild('modelSelect') modelSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetHttpService: AssetBaseHttpService,
    private assetModelHttpService: AssetModelHttpService,
    private statusHttpService: StatusHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      supplier: [],
      location: [],
      itemNo: [],
      assetModel: [null, [], this.v.required.bind(this)],
      note: [],
      isRequestable: [],
      orderNo: [],
      purchaseCost: [],
      purchaseDate: [],
      warranty: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.locationSelect.register((pagination, search) => {
      return this.assetHttpService.locations(pagination, search);
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return this.statusHttpService.list(pagination, search);
    }).fetch();

    this.supplierSelect.register((pagination, search) => {
      return this.assetHttpService.suppliers(pagination, search);
    }).fetch();

    this.modelSelect.register((pagination, search) => {
      return this.assetModelHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.assetHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
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
    this.goTo('/admin/asset');
  }

}
