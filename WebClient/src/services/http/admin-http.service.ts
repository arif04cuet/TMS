import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class AdminHttpService {

    constructor(private httpService: HttpService) {

    }

    inventoryDashboard() {
        const url = `asset/dashboard`
        return this.httpService.get(url);
    }

    hostelDashboard() {
        const url = `hostels/dashboard`
        return this.httpService.get(url);
    }

    libraryDashboard() {
        const url = `libraries/dashboard`
        return this.httpService.get(url);
    }

    trainingDashboard() {
        const url = `training/dashboard`
        return this.httpService.get(url);
    }

}