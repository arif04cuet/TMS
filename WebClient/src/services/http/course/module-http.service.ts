import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ModuleHttpService extends BaseHttpService {

    END_POINT = 'courses/modules';

    listTopics(courseModuleId, pagination, search) {
        let url = `${this.END_POINT}/${courseModuleId}/topics`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    listMethods(courseModuleId) {
        const url = `${this.END_POINT}/${courseModuleId}/methods`
        return this.httpService.get(url);
    }

}