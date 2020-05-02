import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class LibraryHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`libraries/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'libraries?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listLibrarians(pagination = null, search = null) {
        let url = 'libraries/librarians?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('libraries', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`libraries/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`libraries/${id}`, body);
    }

    public listFines(pagination = null, search = null) {
        let url = 'libraries/fines?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

}