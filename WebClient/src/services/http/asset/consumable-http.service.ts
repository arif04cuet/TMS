import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ConsumableHttpService extends AssetBaseHttpService {
    EndPoint = 'consumables';

    public listGroupByItemCode(pagination = null, search = null) {
        let url = this.buildBaseEndpoint() + '/group?';
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public listByItemCode(itemCodeId, pagination = null, search = null) {
        let url = `${this.buildBaseEndpoint()}/${itemCodeId}/items?`;
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }
}