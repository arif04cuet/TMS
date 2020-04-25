import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class PermissionHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public list(userId = 0) {
        return this.httpService.get(`permissions?userId=${userId}`);
    }

    public check(body) {
        return this.httpService.post(`permissions/check`, body);
    }

}