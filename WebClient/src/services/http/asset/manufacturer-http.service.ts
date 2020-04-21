import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class ManufacturerHttpService extends BaseHttpService {

    END_POINT = 'asset/manufacturers';

}