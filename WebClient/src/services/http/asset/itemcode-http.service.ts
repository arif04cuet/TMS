import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ItemCodeHttpService extends AssetBaseHttpService {

    EndPoint = 'itemcodes';

    public listByCategory(categoryId, pagination = null, search = null) {
        let url = `${this.buildBaseEndpoint()}/categories/${categoryId}?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }
}