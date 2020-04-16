import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class PublisherHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`books/publishers/${id}`);
    }

    public list() {
        return this.httpService.get('books/publishers');
    }

    public add(body) {
        return this.httpService.post('books/publishers', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`books/publishers/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`books/publishers/${id}`, body);
    }

}