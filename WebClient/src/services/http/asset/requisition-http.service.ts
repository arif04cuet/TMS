import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class RequisitionHttpService extends BaseHttpService {
    
    END_POINT = `requisitions`

    public submit(body) {
        return this.httpService.post(`${this.END_POINT}/submit`, body);
    }

}