import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class StatusHttpService extends AssetBaseHttpService {

    EndPoint = 'statuses';

    public masterstatuses() {
        return this.httpService.get(this.AssetBaseUri + '/' + this.EndPoint + '/masterstatuses');
    }
}