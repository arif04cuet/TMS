import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class DepreciationHttpService extends BaseHttpService {

    END_POINT = 'asset/depreciations';

}