import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class BookHttpService extends BaseHttpService {

    END_POINT = "books"

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
        return this.httpService.get(this.buildUrl('books/items', pagination, search));
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

    public listIssues(pagination = null, search = null) {
        let url = 'books/issues?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public checkFine(id: number, body) {
        return this.httpService.post(`books/items/${id}/check-fine`, body);
    }

}