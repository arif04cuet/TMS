import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';

@Component({
  selector: 'app-asset-model-add',
  templateUrl: './asset-model-add.component.html'
})
export class AssetModelAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('manufacturerSelect') manufacturerSelect: SelectControlComponent;
  @ViewChild('depreciationSelect') depreciationSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetModelHttpService: AssetModelHttpService,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      category: [null, [], this.v.required.bind(this)],
      manufacturer: [],
      depreciation: [null, [], this.v.required.bind(this)],
      modelNo: [],
      note: [],
      eol: [],
      isRequestable: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.manufacturerSelect.register((pagination, search) => {
      return this.assetModelHttpService.manufacturers(pagination, search);
    }).fetch();

    this.categorySelect.register((pagination, search) => {
      return this.categoryHttpService.listByParent(1, pagination, search);
    }).fetch();

    this.depreciationSelect.register((pagination, search) => {
      return this.assetModelHttpService.depreciations(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.assetModelHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.assetModelHttpService.edit(this.id, body),
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
      this.subscribe(this.assetModelHttpService.get(id),
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
    this.goTo('/admin/asset/models');
  }

}
