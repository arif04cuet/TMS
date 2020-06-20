import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';
import { of } from 'rxjs';

@Injectable()
export class HonorariumHeadHttpService extends BaseHttpService {

    END_POINT = 'trainings/honorarium-heads';

    honorariumForTypes() {
        const data = {
            data: {
                items: [
                    {id: 1, name: 'Participant'},
                    {id: 2, name: 'Resource person'}
                ],
                size: 2
            }
        }
        return of(data);
    }

    latestYearHonorariumHeads(pagination = null, search = null) {
        const url = `trainings/latest-year-honorarium-heads`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }
}