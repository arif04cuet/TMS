import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ResourcePersonHttpService extends BaseHttpService {

    END_POINT = 'courses/resource-persons';

}