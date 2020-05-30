import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class HostelHttpService extends BaseHttpService {

    END_POINT = 'hostels';

    listFloors(hostelId, buildingId, pagination = null, search = null) {
        const url = `${this.END_POINT}/${hostelId}/buildings/${buildingId}/floors`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    listBuildings(hostelId, pagination = null, search = null) {
        const url = `${this.END_POINT}/${hostelId}/buildings`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    listRooms(hostelId, buildingId, floorId, pagination = null, search = null) {
        const url = `${this.END_POINT}/${hostelId}/buildings/${buildingId}/floors/${floorId}/rooms`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    listBeds(hostelId, buildingId, floorId, roomId, pagination = null, search = null) {
        const url = `${this.END_POINT}/${hostelId}/buildings/${buildingId}/floors/${floorId}/rooms/${roomId}/beds`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

}