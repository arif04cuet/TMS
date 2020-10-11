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

    public list(pagination?: string, search?: string) {
        let url = 'books/publishers?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
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