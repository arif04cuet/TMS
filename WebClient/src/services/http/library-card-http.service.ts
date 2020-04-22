import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class LibraryCardHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`libraries/cards/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'libraries/cards?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listTypes(pagination = null, search = null) {
        let url = 'libraries/cards/types?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listStatus(pagination = null, search = null) {
        let url = 'libraries/cards/status?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('libraries/cards', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`libraries/cards/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`libraries/cards/${id}`, body);
    }

}