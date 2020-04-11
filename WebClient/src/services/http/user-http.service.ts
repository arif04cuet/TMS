import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class UserHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`users/${id}`);
    }

    public list(pagination = null, search = null) {
        let url = 'users?'
        if (search) {
            url += search
        }
        if (pagination) {
            url += pagination
        }
        return this.httpService.get(url);
    }

    public add(body) {
        return this.httpService.post('users', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`users/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`users/${id}`, body);
    }

    public getProfile(id) {
        return this.httpService.get(`users/${id}/profile`);
    }

    public updateProfile(id, body) {
        return this.httpService.put(`users/${id}/profile`, body);
    }

    public getPermissions(userId: number) {
        return this.httpService.get(`users/${userId}/permissions`);
    }

    public assignPermissions(userId: number, permissionIds: number[]) {
        const body = { permissions: permissionIds };
        return this.httpService.put(`users/${userId}/permissions`, body);
    }

}