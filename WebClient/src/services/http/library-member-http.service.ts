import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class LibraryMemberHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`library/members/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'library/members?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listTypes(pagination = null, search = null) {
        let url = 'library/cards/types?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public cards(memberId, pagination = null, search = null) {
        let url = `library/members/${memberId}/cards?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('library/members', body);
    }

    public addExisting(body) {
        return this.httpService.post('library/members/register-from-users', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`library/members/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`library/members/${id}`, body);
    }

}