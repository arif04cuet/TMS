import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class ProductsHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public gets() {
        return this.httpService.get('products');
    }

    public get(id) {
        return this.httpService.get(`products/${id}`);
    }

    public add(body) {
        return this.httpService.post('products', body);
    }

    public update(id, body) {
        return this.httpService.put(`products/${id}`, body);
    }

    public delete(id: number) {
        return this.httpService.delete(`products/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`products/${id}`, body);
    }

}