import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class AuthorHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`books/authors/${id}`);
    }

    public list() {
        return this.httpService.get('books/authors');
    }

    public add(body) {
        return this.httpService.post('books/authors', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`books/authors/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`books/authors/${id}`, body);
    }

}