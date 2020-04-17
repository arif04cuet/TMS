import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class CommonHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public getStatus(id) {
        return this.httpService.get(`status/${id}`);
    }

    public getStatusList() {
        return this.httpService.get('status');
    }

    public getGender(id) {
        return this.httpService.get(`genders/${id}`);
    }

    public getGenders() {
        return this.httpService.get('genders');
    }

    public getMaritalStatus(id) {
        return this.httpService.get(`marital-status/${id}`);
    }

    public getMaritalStatusList() {
        return this.httpService.get('marital-status');
    }

    public getReligion(id) {
        return this.httpService.get(`religions/${id}`);
    }

    public getReligions() {
        return this.httpService.get('religions');
    }

    public getBloodGroup(id) {
        return this.httpService.get(`blood-groups/${id}`);
    }

    public getBloodGroups() {
        return this.httpService.get('blood-groups');
    }

    public getLanguages() {
        return this.httpService.get('languages');
    }

    public getDistricts() {
        return this.httpService.get('districts?offset=0&limit=64');
    }

}