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

    public lostBooks(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/lost-books`, pagination, search);
        return this.httpService.get(url);
    }

    public newBooks(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/new-books`, pagination, search);
        return this.httpService.get(url);
    }

    public printIssues(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/issues/export`, pagination, search);
        return this.download(url);
    }

    public printBookEntries(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/book-entries/export`, pagination, search);
        return this.download(url);
    }

    public printAtAGlance(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/at-a-glance/export`, pagination, search);
        return this.download(url);
    }

    public printLostBooks(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/lost-books/export`, pagination, search);
        return this.download(url);
    }

    public printNewBooks(pagination = null, search = null) {
        const url = this.buildUrl(`${this.END_POINT}/new-books/export`, pagination, search);
        return this.download(url);
    }

    private download(url) {
        const req = this.httpService.download(url, {});
        return this.httpService.getClient().request(req);
    }
    

}