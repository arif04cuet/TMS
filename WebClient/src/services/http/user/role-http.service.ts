import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class RoleHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public get(id) {
        return this.httpService.get(`roles/${id}`);
    }

    public list() {
        return this.httpService.get('roles');
    }

    public add(body) {
        return this.httpService.post('roles', body);
    }

    public delete(id: number) {
        return this.httpService.delete(`roles/${id}`);
    }

    public edit(id: number, body) {
        return this.httpService.put(`roles/${id}`, body);
    }

    public getPermissions(userId) {
        console.log(userId);
        return this.httpService.get(`roles/${userId}/permissions`);
    }

    public assignPermissions(userId: number, permissionIds: number[]) {
        const body = { permissions: permissionIds };
        return this.httpService.put(`roles/${userId}/permissions`, body);
    }

}