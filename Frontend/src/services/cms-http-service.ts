import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class CmsHttpService extends BaseHttpService {
    
    public END_POINT = "cms/contents";

    list2(status: string, search: string) {
        if(status) {
            search += `&scheduleStatus=${status}`;
        }
        return super.list(null, search);
    }

    categories(p, s) {
        const url = this.buildUrl(`courses/categories`, p, s)
        return this.httpService.get(url);
    }

    banners(p, s) {
        const url = this.buildUrl(`cms/banners`, p, s)
        return this.httpService.get(url);
    }

    contents(p, s) {
        const url = this.buildUrl(`cms/contents`, p, s)
        return this.httpService.get(url);
    }

    faq(p, s) {
        const url = this.buildUrl(`cms/faq`, p, s)
        return this.httpService.get(url);
    }




}