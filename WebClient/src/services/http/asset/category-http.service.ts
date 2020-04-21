import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class CategoryHttpService extends BaseHttpService {

    END_POINT = 'asset/categories';

    public mastercategories() {
        return this.httpService.get(this.END_POINT + '/mastercategories');
    }
}