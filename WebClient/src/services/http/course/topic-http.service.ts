import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';
import { Observable } from 'rxjs';

@Injectable()
export class TopicHttpService extends BaseHttpService {

    END_POINT = 'courses/topics';

    public listMethods(topicId): Observable<Object> {
        const url = `${this.END_POINT}/${topicId}/methods`
        return this.httpService.get(url);
    }

}