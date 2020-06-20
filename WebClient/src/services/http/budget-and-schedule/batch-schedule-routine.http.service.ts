import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class BatchScheduleRoutineHttpService extends BaseHttpService {

    END_POINT = 'trainings/batch-schedules/class-routines';

    list(batchScheduleId, ...args) {
        let url = `trainings/batch-schedules/${batchScheduleId}/class-routines`;
        url = this.buildUrl(url, ...args);
        return this.httpService.get(url);
    }

}