import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class LibraryHttpService extends BaseHttpService {

    public END_POINT = "libraries";

    public registration(body) {
        const url = `library/members/request`;
        return this.httpService.post(url, body);
    }
    public getCounts() {
        const url = this.END_POINT + '/counts';
        return this.httpService.get(url);
    }

    public listBookItems(pagination = null, search = null) {
        return this.httpService.get(this.buildUrl('books/items', pagination, search));
    }


}