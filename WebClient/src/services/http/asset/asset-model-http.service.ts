import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class AssetModelHttpService extends AssetBaseHttpService {
    EndPoint = `models`
}