import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class MyExamHttpService extends BaseHttpService {
    END_POINT = 'trainings/my-exams';

    submit(body) {
        return this.httpService.post(this.END_POINT, body);
    }
}