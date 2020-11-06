import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class HotelHttpService {

    constructor(private httpService: HttpService) {

    }

    list(pagination = null, search = null) {
        let url = `hostels/rooms-and-beds?`;
        if (pagination) {
            url += `&${pagination}`;
        }
        if (search) {
            url += `&${search}`;
        }
        return this.httpService.get(url);
    }

}