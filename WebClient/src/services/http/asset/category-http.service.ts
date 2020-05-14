import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class CategoryHttpService extends AssetBaseHttpService {

    EndPoint = 'categories';

    public rootCategories() {
        return this.httpService.get(`${this.AssetBaseUri}/${this.EndPoint}/root`);
    }
}