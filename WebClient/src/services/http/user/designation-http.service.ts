import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class DesignationHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`designations/${id}`);
    }

    public list() {
        return this.httpService.get('designations');
    }

    public add(body) {
        return this.httpService.post('designations', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`designations/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`designations/${id}`, body);
    }

}