import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';
import { buildUrl } from '../../utilities.service';

@Injectable()
export class TotalMarksHttpService {

    END_POINT = x => `trainings/batch-schedules/${x}/total-marks`;

    constructor(private httpService: HttpService) {

    }

    list(batchScheduleId, pagination, search) {
        let url = this.END_POINT(batchScheduleId);
        url = buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    update(batchScheduleId, body) {
        const url = this.END_POINT(batchScheduleId);
        return this.httpService.put(url, body);
    }

}