import { Injectable } from '@angular/core';
import { BaseHttpService } from './asset/base-http-service';
import { HttpService } from './http.service';

@Injectable()
export class LibraryReportHttpService extends BaseHttpService {

    END_POINT = 'library/reports';

    constructor(
        public httpService: HttpService
    ) {
        super(httpService);
    }

    public issues(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/issues`, pagination, search);
        return this.httpService.get(url);
    }

    public bookEntries(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/book-entries`, pagination, search);
        return this.httpService.get(url);
    }

    public atAGlance(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/at-a-glance`, pagination, search);
        return this.httpService.get(url);
    }

}