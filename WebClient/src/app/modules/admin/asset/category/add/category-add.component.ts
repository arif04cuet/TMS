import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html'
})
export class CategoryAddComponent extends FormComponent {

  loading: boolean = true;
  savenew: boolean = false;
  mastercategories = [];

  photoUrl;
  photoLoading = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator,
    private mediaHttpService: MediaHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      parentId: [null, [], this.v.required.bind(this)],
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

  handlePhotoChange(e) {
    const file = e.target.files[0];
    if (file) {
      this.photoLoading = true;
      var fr = new FileReader();
      fr.onload = () => {
        this.photoUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          this.log('progress', progress);
        },
        success => {
          this.log('success', success);
          this.form.controls.media.setValue(success.data);
          this.photoLoading = false;
        },
        error => {
          this.photoLoading = false;
        }
      );
    }
  }


  get(id) {
    this.loading = true;

    if (id != null) {
      this.subscribe(this.categoryHttpService.get(id),
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

  getData() {
    this.subscribe(this.categoryHttpService.rootCategories(),
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
