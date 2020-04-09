import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class UserHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`users/${id}`);
    }

    public list() {
        return this.httpService.get('users');
    }

    public add(body) {
        return this.httpService.post('users', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`users/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`users/${id}`, body);
    }

}