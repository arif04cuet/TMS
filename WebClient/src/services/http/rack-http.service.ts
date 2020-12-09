import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BaseHttpService } from './asset/base-http-service';

@Injectable()
export class RackHttpService extends BaseHttpService {

    END_POINT = "libraries/racks";

    public listLibraryRacks(libraryId, pagination = null, search = null) {
        let url = `libraries/${libraryId}/racks?`
        if (pagination) {
            url += pagination
        }
        if (search) {
            url += search
        }
        return this.httpService.get(url);
    }

    public checkDuplicate(form) {

        const library = form.controls.library.value;
        const name = form.controls.name.value;
        const floorNo = form.controls.floorNo.value;
        const buildingName = form.controls.buildingName.value;

        const search = `Search=Name eq ${name}&Search=FloorNo eq ${floorNo}&Search=BuildingName eq ${buildingName}&Search=LibraryId eq ${library}`;

        return this.list(null, search);

    }
}