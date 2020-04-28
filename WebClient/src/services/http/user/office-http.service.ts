import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class OfficeHttpService extends BaseHttpService {
    END_POINT = "offices";
}