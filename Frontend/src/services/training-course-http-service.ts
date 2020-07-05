import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class TrainingCourseHttpService extends BaseHttpService {
    
    public END_POINT = "trainings/batch-schedules";

    list2(status: string, search: string) {
        if(status) {
            search += `&scheduleStatus=${status}`;
        }
        return super.list(null, search);
    }

    categories(p, s) {
        const url = this.buildUrl(`courses/categories`, p, s)
        return this.httpService.get(url);
    }


}