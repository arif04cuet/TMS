import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class CourseScheduleHttpService extends BaseHttpService {

    END_POINT = 'trainings/course-schedules';

    
}