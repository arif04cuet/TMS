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
        return this.httpService.get('libraries');
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

}