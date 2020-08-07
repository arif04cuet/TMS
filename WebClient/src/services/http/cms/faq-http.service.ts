import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class FaqHttpService extends BaseHttpService {

    END_POINT = 'cms/faq';

}