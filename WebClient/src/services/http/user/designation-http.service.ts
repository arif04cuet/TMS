import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class DesignationHttpService extends BaseHttpService {
    END_POINT = 'designations';
}