import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ModuleHttpService extends BaseHttpService {

    END_POINT = 'courses/modules';

}