import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ExpertiseHttpService extends BaseHttpService {

    END_POINT = 'courses/expertise';

}