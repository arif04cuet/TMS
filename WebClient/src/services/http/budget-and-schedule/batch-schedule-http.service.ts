import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class BatchScheduleHttpService extends BaseHttpService {

    END_POINT = 'trainings/batch-schedules';

    listParticipant(scheduleId, pagination, search) {
        let url = `${this.END_POINT}/${scheduleId}/participants`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    listModules(batchScheduleId, pagination, search) {
        let url = `${this.END_POINT}/${batchScheduleId}/modules`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }


}