import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BannerHttpService } from 'src/services/http/cms/banner-http.service';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';



@Component({
  selector: 'app-banner-add',
  templateUrl: './banner-add.component.html'
})
export class BannerAddComponent extends FormComponent {

  loading: boolean = true;

  mediaUrl;
  mediaLoading = false;



  constructor(
    private activatedRoute: ActivatedRoute,
    private bannerHttpService: BannerHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      media: [null, [], this.v.required.bind(this)],
      isActive: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }


  submit(): void {
    //const body = this.constructObject(this.form.controls);

    const body = this.constructObject(this.form.controls);

    this.submitForm(
      {
        request: this.bannerHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.bannerHttpService.edit(this.id, body),
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
      this.subscribe(this.bannerHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;

          if (res.data.media) {
            this.mediaUrl = `${environment.serverUri}/${res.data.mediaUrl}`;
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
    this.goTo('/admin/cms/banners');
  }

  imageDeleteHandler = imageId => {
    return this.bannerHttpService
      .deleteImage(imageId, this.id || null)
      .pipe(
        map(x => {
          console.log('image deleted', x);
          return true
        }),
        catchError(_ => of(false))
      );
  }

}
