import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UploadFile } from 'ng-zorro-antd';
import { BatchScheduleGalleryHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-gallery-http.service';
import { BaseComponent } from 'src/app/shared/base.component';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-batch-schedule-gallery',
  templateUrl: './batch-schedule-gallery.component.html'
})
export class BatchScheduleGalleryComponent extends BaseComponent {

  loading = false;
  total = 0;
  showUploadList = {
    showPreviewIcon: true,
    showRemoveIcon: true,
    hidePreviewIconInNonImage: true
  };
  fileList = [];
  previewImage: string | undefined = '';
  previewVisible = false;
  uploadUrl = '';
  allowedFileType = 'image/png,image/jpeg,image/jpg'

  private id;

  constructor(
    private batchScheduleGalleryHttpService: BatchScheduleGalleryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    this.id = snapshot.params.id;
    this.uploadUrl = `${environment.baseUrl}/trainings/batch-schedules/${this.id}/galleries/upload`;
    this.gets();
  }

  gets() {
    this.loading = true;
    this.subscribe(this.batchScheduleGalleryHttpService.list(this.id),
      (res: any) => {
        this.total = res.data.size;
        const items = res.data.items.map(x => {
          return {
            uid: x.id,
            name: 'xxx.png',
            status: 'done',
            url: `${environment.serverUri}/${x.path}`
          }
        });
        this.fileList = items;
        this.loading = false;
      },
      err => {
        this.loading = false;
      }
    )
  }

  refresh() {
    this.gets();
  }

  handleChange(e) {
    console.log('changed', e);
    if(e.type == "removed") {
      this.total--;
    }
    else if (e.type == "success") {
      this.total++;
    }
  }

  handlePreview = (file: UploadFile) => {
    this.previewImage = file.url || file.thumbUrl;
    this.previewVisible = true;
  };

  handleRemove = (file: UploadFile) =>  {
    const r = this.batchScheduleGalleryHttpService
                .delete(this.id, file.uid)
                .pipe(
                  map(x => true),
                  catchError(_ => of(true))
                );
    return r;
  }

}
