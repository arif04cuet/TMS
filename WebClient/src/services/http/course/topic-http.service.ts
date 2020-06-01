import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class TopicHttpService extends BaseHttpService {

    END_POINT = 'courses/topics';

}