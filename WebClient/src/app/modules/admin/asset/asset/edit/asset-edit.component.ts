import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-asset-edit',
  templateUrl: './asset-edit.component.html'
})
export class AssetEditComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('statusSelect') statusSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;
  @ViewChild('modelSelect') modelSelect: SelectControlComponent;

  photoUrl;
  eol;

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
      assetTag: [null, [], this.v.required.bind(this)],
      name: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      supplier: [],
      location: [],
      itemNo: [],
      assetModel: [null, [], this.v.required.bind(this)],
      note: [],
      isRequestable: [],
      orderNo: [],
      purchaseCost: [null, [], this.v.required.bind(this)],
      purchaseDate: [null, [], this.v.required.bind(this)],
      warranty: [],
      maintenance: [],
      eol: [null, [], this.v.required.bind(this)],
      media: []
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
    const body: any = this.constructObject(this.form.controls);
    if (this.id) {
      body.id = Number(this.id);
    }
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
          this.photoUrl = environment.serverUri + '/' + res.data.photo;
          const date = new Date(res.data.purchaseDate);
          const depreciationTerm = res.data.depreciation ? res.data.depreciation.term : 0;
          this.eol = new Date(date.setMonth(date.getMonth()+depreciationTerm));
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
