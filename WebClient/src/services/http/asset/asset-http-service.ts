import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class AssetBaseHttpService {

    public AssetBaseUri = 'asset';
    public EndPoint;

    constructor(public httpService: HttpService) {

    }

    public categories(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/categories' + '?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public manufacturers(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/manufacturers' + '?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public suppliers(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/suppliers' + '?';
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
    }

    public locations(pagination = null, search = null) {
        let url = 'offices' + '?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public dereciations(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/depreciations' + '?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public getStatus() {
        var status = [
            { id: true, name: 'Active' },
            { id: false, name: 'In Active' }
        ];
        return status;
    }

    public get(id) {
        return this.httpService.get(this.AssetBaseUri + '/' + this.EndPoint + '/' + `${id}`);
    }

    public list(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/' + this.EndPoint + '?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public add(body) {
        return this.httpService.post(this.AssetBaseUri + '/' + this.EndPoint, body);
    }

    public delete(id: number) {
        return this.httpService.delete(this.AssetBaseUri + '/' + this.EndPoint + '/' + `${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(this.AssetBaseUri + '/' + this.EndPoint + '/' + `${id}`, body);
    }

    public checkout(id: number, body) {
        return this.httpService.post(`${this.AssetBaseUri}/${this.EndPoint}/${id}/checkouts`, body);
    }

    public checkin(id: number, body) {
        return this.httpService.post(`${this.AssetBaseUri}/${this.EndPoint}/${id}/checkins`, body);
    }

    public listCheckouts(id, pagination = null, search = null) {
        let url = `${this.AssetBaseUri}/${this.EndPoint}/${id}/checkouts?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public listCheckoutHistory(id, pagination = null, search = null) {
        let url = `${this.AssetBaseUri}/${this.EndPoint}/${id}/histories?`;
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

    public getCheckout(id: number, checkoutId: number) {
        return this.httpService.get(`${this.AssetBaseUri}/${this.EndPoint}/${id}/checkouts/${checkoutId}`);
    }
}