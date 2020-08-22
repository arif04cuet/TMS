import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class RequisitionHttpService extends BaseHttpService {
    END_POINT = `requisitions`
}