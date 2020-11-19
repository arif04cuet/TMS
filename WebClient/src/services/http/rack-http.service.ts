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

}