import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class AssetReportsHttpService {
    
    EndPoint = 'asset/reports';

    constructor(public httpService: HttpService) {

    }

    public activityLog(pagination = null, search = null) {
        let url = `${this.EndPoint}/activity-log?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public auditLog(pagination = null, search = null) {
        let url = `asset/audit?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public depreciation(pagination = null, search = null) {
        let url = `${this.EndPoint}/depreciation?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public license(pagination = null, search = null) {
        let url = `${this.EndPoint}/license?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public maintenance(pagination = null, search = null) {
        let url = `${this.EndPoint}/maintenance?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
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