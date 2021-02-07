import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ResourcePersonHttpService extends BaseHttpService {

    END_POINT = 'courses/resource-persons';

    public assignableUsersList(pagination = null, search = null): Observable<Object> {
        const url = `${this.END_POINT}/assignable-users`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    deleteImage(imageId, entityId = null) {
        const url = `${this.END_POINT}/${entityId}/images/${imageId}`
        return this.httpService.delete(url);
    }

}