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

    listEvaluationMethods(batchScheduleId, pagination, search) {
        let url = `${this.END_POINT}/${batchScheduleId}/evaluation-methods`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    dropdown(pagination, search) {
        let url = `${this.END_POINT}/dropdown`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    downloadHonorariumSheet(batchScheduleId) {
        const url = `${this.END_POINT}/${batchScheduleId}/honorarium-sheet`;
        const req = this.httpService.download(url, {});
        return this.httpService.getClient().request(req);
    }


}