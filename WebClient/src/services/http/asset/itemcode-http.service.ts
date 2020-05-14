import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ItemCodeHttpService extends AssetBaseHttpService {

    EndPoint = 'itemcodes';


}