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
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
    }

    public manufacturers(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/manufacturers' + '?';
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
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
        let url = this.AssetBaseUri + '/locations' + '?';
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
    }

    public dereciations(pagination = null, search = null) {
        let url = this.AssetBaseUri + '/depreciations' + '?';
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
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
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
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
}