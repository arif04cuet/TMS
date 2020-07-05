import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';
import { of } from 'rxjs';

@Injectable()
export class ExamHttpService extends BaseHttpService {

    END_POINT = 'trainings/batch-schedules/exams';

    list2(batchScheduleId, pagination, search) {
        let url = `trainings/batch-schedules/${batchScheduleId}/exams`;
        url = this.buildUrl(url, pagination, search);
        return this.httpService.get(url);
    }

    listStatus() {
        const data = {
            data: {
                items: [
                    {id: 1, name: 'Completed'},
                    {id: 2, name: 'Pending'}
                ],
                size: 2
            }
        }
        return of(data);
    }

    result(batchScheduleId, examId) {
        const url = `trainings/batch-schedules/${batchScheduleId}/exams/${examId}/result`;
        return this.httpService.get(url);
    }

    updateResult(examId, body) {
        const url = `${this.END_POINT}/${examId}/result`;
        return this.httpService.put(url, body);
    }

}