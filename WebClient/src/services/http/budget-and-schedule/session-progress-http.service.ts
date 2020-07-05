import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';

@Injectable()
export class SessionProgressHttpService {

    END_POINT = 'trainings/batch-schedules/session-progress';

    constructor(public httpService: HttpService) {

    }

    list(batchScheduleId, moduleId = null) {
        let url = `${this.END_POINT}?batchScheduleId=${batchScheduleId}`;
        if (moduleId) {
            url += `&moduleId=${moduleId}`
        }
        return this.httpService.get(url);
    }

    completeMultiple(body) {
        const url = `${this.END_POINT}/complete`;
        return this.httpService.post(url, body);
    }

    completeMultipleAndGenerateSheet(batchScheduleId, body) {
        const url = `trainings/batch-schedules/${batchScheduleId}/session-progress/complete-and-generate-sheet`;
        const req = this.httpService.download(url, body);
        return this.httpService.getClient().request(req);
    }

    complete(routinePeriodId) {
        const url = `${this.END_POINT}/${routinePeriodId}/complete`;
        return this.httpService.post(url, {});
    }

    completeAndGenerateSheet(batchScheduleId, routinePeriodId) {
        const url = `trainings/batch-schedules/${batchScheduleId}/session-progress/${routinePeriodId}/complete-and-generate-sheet`;
        const req = this.httpService.download(url, {});
        return this.httpService.getClient().request(req);
    }


}