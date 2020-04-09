import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class PermissionsHttpService {

    constructor(
        private httpService: HttpService
    ) { }

    public getResources() {
        return this.httpService.get('permissions/resources');
    }

    public getResourceGroups() {
        return this.httpService.get('permissions/resources/groups');
    }

    public deleteResourceGroup(id: number) {
        return this.httpService.delete(`permissions/resources/groups/${id}`);
    }

    public deleteResourceGroups(ids: number[]) {
        const q = ids.map(x => `ids=${x}`).join('&')
        return this.httpService.delete(`permissions/resources/groups?${ids}`);
    }

    public addResourceGroups(body) {
        return this.httpService.post('permissions/resources/groups', body);
    }

    public editResourceGroups(id, body) {
        return this.httpService.put(`permissions/resources/groups/${id}`, body);
    }

    public getResource() {

    }

    public scans() {
        return this.httpService.get('permissions/scans');
    }

    public seeds() {
        return this.httpService.post('permissions/seeds', null);
    }

}