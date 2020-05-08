import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { environment } from 'src/environments/environment';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';

@Component({
  selector: 'app-asset-model-add',
  templateUrl: './asset-model-add.component.html'
})
export class AssetModelAddComponent extends FormComponent {

  loading: boolean = true;

  photoUrl;
  photoLoading = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetModelHttpService: AssetModelHttpService,
    private v: CommonValidator,
    private mediaHttpService: MediaHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      type: [null, [], this.v.required.bind(this)],
      eula: [null, []],
      isRequireUserConfirmation: [null, []],
      isSendEmail: [null, []],
      isActive: [null, []],
      media: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);

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
          console.log(`${environment}`);
          if (res.data.photo) {
            this.photoUrl = `${environment.serverUri}/${res.data.photo}`;
          }
        }
      );
    }
    else {
      this.form.controls.isActive.setValue(true);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/asset/models');
  }

}
