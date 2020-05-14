import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';


import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';

@Component({
  selector: 'app-itemcode-add',
  templateUrl: './itemcode-add.component.html'
})
export class ItemCodeAddComponent extends FormComponent {

  loading: boolean = true;
  savenew: boolean = false;

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private itemcodeHttpService: ItemCodeHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      code: [null, [], this.v.required.bind(this)],
      categoryId: [null, [], this.v.required.bind(this)],
      minQuantity: [null, [], this.v.required.bind(this)],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.categorySelect.register((pagination, search) => {
      return this.itemcodeHttpService.categories(pagination, search);
    }).fetch();


  }

  submit(): void {
    const body = this.constructObject(this.form.controls);

    this.submitForm(
      {
        request: this.itemcodeHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.itemcodeHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  save_new() {
    this.savenew = true;
    this.submit();
  }


  get(id) {
    this.loading = true;

    if (id != null) {
      this.subscribe(this.itemcodeHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.isActive.setValue(true);
      this.loading = false;

    }
  }

  getData() {

  }

  cancel() {
    if (this.savenew) {
      this.form.reset();
      this.savenew = false;
      this.goTo('/admin/asset/itemcodes/add');
    }
    else
      this.goTo('/admin/asset/itemcodes');
  }

}
