import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs';

@Injectable()
export class BaseHttpService {

    public END_POINT;

    constructor(public httpService: HttpService) {

    }

    public getStatus() {
        var status = [
            { id: true, name: 'Active' },
            { id: false, name: 'In Active' }
        ];
        return status;
    }
    public get(id) {
        return this.httpService.get(this.END_POINT + '/' + `${id}`);
    }

    public list(pagination = null, search = null): Observable<Object> {
        return this.httpService.get(this.buildUrl(this.END_POINT, pagination, search));
    }

    public add(body) {
        return this.httpService.post(this.END_POINT, body);
    }

    public delete(id: number) {
        return this.httpService.delete(this.END_POINT + '/' + `${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(this.END_POINT + '/' + `${id}`, body);
    }

    public buildUrl(url: string, ...args) {
        const _args = args.filter(x => x);
        const _url = `${url}?${_args.join('&')}`;
        return _url;
    }
}