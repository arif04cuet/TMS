import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';
import { of } from 'rxjs';

@Injectable()
export class QuestionHttpService extends BaseHttpService {

    END_POINT = 'trainings/questions';

    listTypes() {
        const obj = {
            data: {
                items: [
                    { id: 1, name: 'MCQ' },
                    { id: 2, name: 'Written' }
                ],
                size: 2
            }
        }
        return of(obj)
    }

}