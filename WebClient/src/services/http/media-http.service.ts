import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';

@Injectable()
export class MediaHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    upload(file: any, isPublic, onProgress, onSuccess, onError?) {
        this.uploadWithUrl(`media/upload`, file, isPublic, onProgress, onSuccess, onError)
    }

    uploadWithUrl(url: string, file: any, isPublic, onProgress, onSuccess, onError?) {
        let q = '';
        if (isPublic) {
            q += `&isPublic=${isPublic}`;
        }
        const data = new FormData();
        data.append('file', file);
        const req = this.httpService.postFromData(`${url}?${q}`, data);
        this.handleRequest(req, onProgress, onSuccess, onError);
    }

    download(url: string, onProgress, onSuccess, onError?) {
        const req = this.httpService.download(url, null);
        this.handleRequest(req, onProgress, onSuccess, onError);
    }

    downloadWithUrl(url: string) {
        window.open(url);
    }

    delete(id) {
        return this.httpService.delete(`media/${id}`);
    }

    handleRequest(req: HttpRequest<any>, progress, success, error) {
        this.httpService.getClient().request(req).subscribe(
            event => {
                if (event.type === HttpEventType.UploadProgress) {
                    if (progress) {
                        progress(Math.round(100 * event.loaded / event.total));
                    }
                } else if (event instanceof HttpResponse) {
                    if (success) {
                        success(event.body);
                    }
                } else if (event.type === HttpEventType.DownloadProgress) {
                    if (progress) {
                        progress(event.loaded);
                    }
                }
            },
            err => {
                if (error) {
                    error(err);
                }
            }
        );
    }

}