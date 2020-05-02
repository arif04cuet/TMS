import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

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

    public list(pagination = null, search = null) {
        let url = this.END_POINT + '?';
        if (search) {
            url += `${search}&`
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
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
}