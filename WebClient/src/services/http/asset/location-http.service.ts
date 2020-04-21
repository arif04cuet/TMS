import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class LocationHttpService extends BaseHttpService {

    END_POINT = 'asset/locations';

}