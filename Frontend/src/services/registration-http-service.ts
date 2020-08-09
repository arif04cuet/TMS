import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class RegistrationHttpService {
    
    constructor(private httpService: HttpService) {
        
    }

    registration(body) {
        const url = `users/registration-from-frontend`;
        return this.httpService.post(url, body);
    }

    designations() {
        const url = `designations?offset=0&limit=1000`;
        return this.httpService.get(url);
    }

}