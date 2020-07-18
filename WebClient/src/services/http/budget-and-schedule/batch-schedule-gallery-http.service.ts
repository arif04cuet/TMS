import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs';
import { buildUrl } from 'src/services/utilities.service';
import { MediaHttpService } from '../media-http.service';

@Injectable()
export class BatchScheduleGalleryHttpService {

    constructor(
        private httpService: HttpService,
        private mediaHttpService: MediaHttpService) {
        
    }

    public get(batchScheduleId, galleryItemId) {
        return this.httpService.get(this.getUrl(batchScheduleId, galleryItemId));
    }

    public list(batchScheduleId, pagination = null, search = null): Observable<Object> {
        return this.httpService.get(buildUrl(this.getUrl(batchScheduleId), pagination, search));
    }

    public add(file: any, batchScheduleId, onProgress, onSuccess, onError?) {
        this.mediaHttpService.uploadWithUrl(this.getUrl(batchScheduleId), file, true, onProgress, onSuccess, onError);
    }

    public delete(batchScheduleId, galleryItemId) {
        return this.httpService.delete(this.getUrl(batchScheduleId, galleryItemId));
    }

    private getUrl(batchScheduleId, galleryItemId?) {
        let url = `trainings/batch-schedules`;
        if(batchScheduleId) {
            url += `/${batchScheduleId}/galleries`;
        }
        if(galleryItemId) {
            url += `/${galleryItemId}`;
        }
        return url;
    }


}