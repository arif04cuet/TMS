import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class BedHttpService extends BaseHttpService {

    END_POINT = 'hostels/beds';

}