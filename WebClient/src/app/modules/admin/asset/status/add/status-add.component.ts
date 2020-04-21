import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-status-add',
  templateUrl: './status-add.component.html'
})
export class StatusAddComponent extends FormComponent {

  loading: boolean = true;

  statuses = [];
  masterstatuses = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private statusHttpService: StatusHttpService,
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
      color: [null, []],
      note: [null, []],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.statusHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.statusHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;

    this.subscribe(this.statusHttpService.masterstatuses(),
      (res: any) => {
        this.masterstatuses = res.data.items;
      }
    );

    if (id != null) {
      this.subscribe(this.statusHttpService.get(id),
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
    this.goTo('/admin/asset/statuses');
  }

}
