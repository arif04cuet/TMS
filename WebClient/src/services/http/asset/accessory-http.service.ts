import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class AccessoryHttpService extends AssetBaseHttpService {
    EndPoint = 'accessories';
}