import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class AssetAuditHttpService {

    constructor(private httpService: HttpService) {

    }

    public get(id) {
        return this.httpService.get(`asset/audit/${id}`);
    }

    public list(assetId, pagination = null, search = null) {
        let url = `asset/${assetId}/audit?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public listAll(pagination = null, search = null) {
        let url = `asset/audit?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public add(body) {
        return this.httpService.post(`asset/audit`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`asset/audit/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`asset/audit/${id}`, body);
    }

    public buildUrl(url, pagination, search) {
        if (search) {
            url += `${search}&`
        }
        if (pagination) {
            url += pagination
        }
        return url;
    }

}