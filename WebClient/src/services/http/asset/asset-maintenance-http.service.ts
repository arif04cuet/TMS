import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class AssetMaintenanceHttpService {

    constructor(private httpService: HttpService) {

    }

    public get(id) {
        return this.httpService.get(`asset/maintenances/${id}`);
    }

    public list(assetId, pagination = null, search = null) {
        let url = `asset/${assetId}/maintenances?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public listAll(pagination = null, search = null) {
        let url = `asset/maintenances?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public add(body) {
        return this.httpService.post(`asset/maintenances`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`asset/maintenances/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`asset/maintenances/${id}`, body);
    }

    public types() {
        return this.httpService.get(`asset/maintenances/types`);
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