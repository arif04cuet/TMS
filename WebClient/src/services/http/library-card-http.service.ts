import { Injectable } from '@angular/core';
import { BaseHttpService } from './asset/base-http-service';

@Injectable()
export class LibraryCardHttpService extends BaseHttpService {

    END_POINT = "libraries/cards";

    public listTypes(pagination = null, search = null) {
        let url = `${this.END_POINT}/types?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listStatus(pagination = null, search = null) {
        let url = `${this.END_POINT}/status?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public listAssignableCards(pagination = null, search = null) {
        let url = `${this.END_POINT}/assignable?`
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

}