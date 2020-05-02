import { Injectable } from '@angular/core';
import { BaseHttpService } from './asset/base-http-service';

@Injectable()
export class LibraryMemberHttpService extends BaseHttpService {

    END_POINT = "library/members";

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

    public cards(pagination = null, search = null) {
        let url = `${this.END_POINT}/cards?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public addExisting(body) {
        return this.httpService.post(`${this.END_POINT}/register-from-users`, body);
    }

}