import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class CategoryHttpService extends BaseHttpService {

    END_POINT = 'courses/categories';

}