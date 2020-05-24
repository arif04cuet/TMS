import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class FacilitiesHttpService extends BaseHttpService {

    END_POINT = 'hostels/facilities';

}