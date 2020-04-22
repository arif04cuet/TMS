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

    public addBookItem(body) {
        return this.httpService.post('books/items', body);
    }

    public deleteBookItem(id: number) {
        return this.httpService.delete(`books/items/${id}`);
    }

    public editBookItem(id: number, body) {
        return this.httpService.put(`books/items/${id}`, body);
    }

    public issueBookItem(id: number, body) {
        return this.httpService.post(`books/items/${id}/issue`, body);
    }

    public returnBookItem(id: number, body) {
        return this.httpService.post(`books/items/${id}/return`, body);
    }

    public getBookItem(id) {
        return this.httpService.get(`books/items/${id}`);
    }

    public getBookItemIssue(id) {
        return this.httpService.get(`books/items/${id}/issue`);
    }

    public listBookItems(pagination = null, search = null) {
        let url = 'books/items?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listBookStatus(pagination = null, search = null) {
        let url = 'books/status?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listBookFormats(pagination = null, search = null) {
        let url = 'books/formats?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public getEditions(bookId, pagination = null, search = null) {
        let url = `books/${bookId}/editions?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

}