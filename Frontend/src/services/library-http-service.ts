import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class LibraryHttpService extends BaseHttpService {
    
    public END_POINT = "libraries";

    registration(body) {
        const url = `library/members/request`;
        return this.httpService.post(url, body);
    }
    

}