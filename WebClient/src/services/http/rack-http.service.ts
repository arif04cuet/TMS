import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class RackHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`libraries/racks/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'libraries/racks?'
        if(pagination){
            url += pagination
        }
        if(search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('libraries/racks', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`libraries/racks/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`libraries/racks/${id}`, body);
    }

}