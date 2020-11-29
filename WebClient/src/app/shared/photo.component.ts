import { Component, Input, NgModule, ChangeDetectionStrategy } from '@angular/core';
import { SharedModule } from './shared.module';
import { NgZorroAntdModule, NzMessageService } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-photo-upload',
  template: `
  <div>
    <label>{{label|translate}}</label>
  </div>
  <div [class]="uploaderClass + ' cursor-pointer' ">
    <div class="container">
        <input [accept]="accept" (change)="handlePhotoChange($event)" #photo type="file" style="display: none;">
        <div class="placeholder" *ngIf="!photoLoading && !photoUrl">
            <i nz-icon [nzType]="photoLoading ? 'loading' : 'plus'"></i>
            <span>{{ 'no.photo'|translate }}</span>
            <span *ngIf="accept.length>0">{{ 'only'|translate }} {{ accept}} {{ 'files'|translate }}</span>
        </div>
        <i *ngIf="photoLoading" nz-icon nzType="loading" style="font-size: 24px;"></i>
        <img *ngIf="!photoLoading && photoUrl && type == 'image'" [src]="photoUrl" class="photo" />
        <div *ngIf="!photoLoading && type == 'file'" >
        <div>
          <a class="icon" (click)="handleUpload($event); photo.click()">
            <i nz-icon nzType="upload" nzTheme="outline" style="font-size:30px"></i>
          </a>
          <br/>
          <a *ngIf="!photoLoading && photoUrl && type == 'file'" [href]="photoUrl" target="__blank">Download</a>
          <a *ngIf="photoUrl && delete" class="icon" (click)="handleDelete($event)" style="margin-left:10px">
            <i nz-icon nzType="delete" nzTheme="outline"></i>
          </a>
        </div>
      </div>
      <div *ngIf="!photoLoading && type == 'image'" class="overlay">
        <div>
          <a class="icon" (click)="handleUpload($event); photo.click()">
            <i nz-icon nzType="upload" nzTheme="outline"></i>
          </a>
          <a *ngIf="photoUrl && delete" class="icon" (click)="handleDelete($event)">
            <i nz-icon nzType="delete" nzTheme="outline"></i>
          </a>
        </div>
      </div>
    </div>
  </div>
  `
})
export class PhotoUploadComponent {

  @Input() uploaderClass: string = 'rectangular-uploader';
  @Input() label;
  @Input() type: string = "image";
  @Input() photoUrl;
  @Input() control: FormControl;
  @Input() delete: (mediaId: any) => Observable<boolean>;
  @Input() accept: string = "";

  photoLoading: boolean = false;

  constructor(
    private mediaHttpService: MediaHttpService,
    private messageService: NzMessageService,
    private translateService: TranslateService
  ) {
  }

  handlePhotoChange(e) {
    const file = e.target.files[0];
    if (file) {

      // check file extension
      if (this.accept.length > 0) {
        var fileName = file.name;
        var ext = fileName.substr(fileName.lastIndexOf('.') + 1);

        console.log(this.accept.split(","));
        if (!this.accept.split(",").includes("." + ext)) {
          this.control.setErrors({ 'incorrect': true });
          this.translateService.get('only.x0.files', { x0: this.accept }).subscribe(x => {
            this.messageService.error(x);
          });
          return false;
        }
      }

      this.photoLoading = true;
      var fr = new FileReader();
      fr.onload = () => {
        this.photoUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          // console.log('progress', progress);
        },
        success => {
          this.control.setValue(success.data);
          this.photoLoading = false;
          this.translateService.get('successfully.uploaded').subscribe(x => {
            this.messageService.success(x);
          });
        },
        error => {
          this.photoLoading = false;
          this.translateService.get('can.not.be.uploaded').subscribe(x => {
            this.messageService.error(x);
          });
        }
      );
    }
  }

  handleDelete(e) {
    console.log('photo delete', e);
    this.photoLoading = true;
    if (this.delete) {
      this.delete(this.control.value).subscribe(
        res => {
          this.photoLoading = false;
          if (res) {
            // deleted
            this.photoUrl = null;
            this.translateService.get('successfully.deleted').subscribe(x => {
              this.messageService.success(x);
            });
          }
          else {
            this.translateService.get('can.not.be.deleted').subscribe(x => {
              this.messageService.error(x);
            });
          }
        },
        err => {
          this.photoLoading = false;
        }
      );

    }
  }

  handleUpload(e) {
    console.log('photo upload', e);
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
    MediaHttpService,
    NzMessageService,
    TranslateService
  ]
})
export class PhotoUploadModule {

}