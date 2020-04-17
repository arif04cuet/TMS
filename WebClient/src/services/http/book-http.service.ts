import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class BookHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`books/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'books?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('books', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`books/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`books/${id}`, body);
    }

}