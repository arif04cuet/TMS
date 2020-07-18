import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class CourseScheduleHttpService extends BaseHttpService {

    END_POINT = 'trainings/course-schedules';

    public listBudget(pagination = null, search = null) {
        const url = `${this.END_POINT}/budgets`
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    detailsAutocomplete(term: string) {
        const url = `${this.END_POINT}/budgets/details-autocomplete?term=${term}`;
        return this.httpService.get(url);
    }

}