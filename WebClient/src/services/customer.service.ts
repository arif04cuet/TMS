import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';

@Injectable()
export class CustomerService {

    constructor(
        private httpService: HttpService
    ) { }

    public gets() {
        return this.httpService.get('customers');
    }

    public get(id) {
        return this.httpService.get(`customers/${id}`);
    }

    public add(body) {
        return this.httpService.post('customers', body);
    }

    public update(id, body) {
        return this.httpService.put(`customers/${id}`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`customers/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`customers/${id}`, body);
    }

}