import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html'
})
export class CategoryAddComponent extends FormComponent {

  loading: boolean = true;
  savenew: boolean = false;
  mastercategories = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      type: [null, [], this.v.required.bind(this)],
      eula: [null, []],
      isRequireUserConfirmation: [null, []],
      isSendEmail: [null, []],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.categoryHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.categoryHttpService.edit(this.id, body),
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
      this.subscribe(this.categoryHttpService.get(id),
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
    this.subscribe(this.categoryHttpService.mastercategories(),
      (res: any) => {
        this.mastercategories = res.data.items;
      }
    );
  }

  cancel() {
    if (this.savenew) {
      this.form.reset();
      this.savenew = false;
      this.goTo('/admin/asset/categories/add');
    }
    else
      this.goTo('/admin/asset/categories');
  }

}
