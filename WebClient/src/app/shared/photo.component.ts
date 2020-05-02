import { Component, Input, NgModule, ChangeDetectionStrategy } from '@angular/core';
import { SharedModule } from './shared.module';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-photo-upload',
  template:  `
  <div>
    <label>{{label|translate}}</label>
  </div>
  <div (click)="photo.click()" class="photo-uploader cursor-pointer">
    <div class="container">
        <input (change)="handlePhotoChange($event)" #photo type="file" style="display: none;">
        <div class="placeholder" *ngIf="!photoLoading && !photoUrl">
            <i nz-icon [nzType]="photoLoading ? 'loading' : 'plus'"></i>
            <span>{{'choose.photo'|translate}}</span>
        </div>
        <i *ngIf="photoLoading" nz-icon nzType="loading" style="font-size: 24px;"></i> 
        <img *ngIf="!photoLoading && photoUrl" [src]="photoUrl" class="photo" />
    </div>
  </div>
  `
})
export class PhotoUploadComponent {

  @Input() label;
  @Input() photoUrl;
  @Input() control: FormControl;

  photoLoading: boolean = false;

  constructor(
    private mediaHttpService: MediaHttpService
  ) {
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
          console.log('progress', progress);
        },
        success => {
          console.log('success', success);
          this.control.setValue(success.data);
          this.photoLoading = false;
        },
        error => {
          this.photoLoading = false;
        }
      );
    }
  }

}

@NgModule({
  imports: [
    SharedModule,
    NgZorroAntdModule,
    CommonModule
  ],
  declarations: [
    PhotoUploadComponent
  ],
  exports: [
    PhotoUploadComponent
  ],
  providers: [
    MediaHttpService
  ]
})
export class PhotoUploadModule {
  
}