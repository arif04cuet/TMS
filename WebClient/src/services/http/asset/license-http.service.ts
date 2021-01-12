import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class LicenseHttpService extends AssetBaseHttpService {

    EndPoint = 'licenses';

    public getDetails(id) {
        return this.httpService.get(this.AssetBaseUri + '/' + this.EndPoint + '/' + `${id}` + '/details');
    }

    deleteSeat(id) {
        return this.httpService.delete(this.AssetBaseUri + '/' + this.EndPoint + '/deleteSeat/' + id);
    }
}