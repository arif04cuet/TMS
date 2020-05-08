import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ConsumableHttpService extends AssetBaseHttpService {
    EndPoint = 'consumables';
}