import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class SubjectHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`books/subjects/${id}`);
    }

    public list() {
        return this.httpService.get('books/subjects');
    }

    public add(body) {
        return this.httpService.post('books/subjects', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`books/subjects/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`books/subjects/${id}`, body);
    }

}