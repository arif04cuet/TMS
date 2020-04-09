import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class DepartmentHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`departments/${id}`);
    }

    public list() {
        return this.httpService.get('departments');
    }

    public add(body) {
        return this.httpService.post('departments', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`departments/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`departments/${id}`, body);
    }

}