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

    apply(id, data) {
        const url = this.buildUrl(`courses/${id}/apply`)
        return this.httpService.post(url, data);
    }

    beds(pagination = null, search = null) {
        const url = `hostels/beds`
        return this.httpService.get(this.buildUrl(url, pagination, search, 'Search=IsBooked eq false'));
    }

    public batchAllocation(batchId) {
        const url = "trainings/batch-schedules/allocations";
        return this.httpService.get(this.buildUrl(url, null, null, `Search=BatchScheduleId eq ${batchId}`));
    }



}