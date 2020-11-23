import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class CategoryHttpService extends AssetBaseHttpService {

    EndPoint = 'categories';

    public listByParent(parentId, pagination = null, search = null) {
        let url = this.buildBaseEndpoint() + '?';
        if (parentId) {
            url += `parentId=${parentId}&`
        }
        return this.httpService.get(this.buildUrl(url, pagination, search));
    }

    public rootCategories() {
        return this.httpService.get(`${this.AssetBaseUri}/${this.EndPoint}/root`);
    }

    public masterCategories() {
        return [
            "Asset",
            "Consumable",
            "License",
            'সম্পদ',
            'ভোগ্য সম্পদ',
            'লাইসেন্স',
            'স্থাবর সম্পদ',
            'অস্থাবর সম্পদ'
        ];
    }
}