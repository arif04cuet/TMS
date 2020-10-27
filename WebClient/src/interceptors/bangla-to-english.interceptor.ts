import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { toBengali, convertValueToEnglish } from 'src/services/utilities.service';


@Injectable()
export class BanglaToEnglishInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const body = request.body;

        if (this.allowed(request.url)) {

            for (const key in body) {
                if (this.attributes().includes(key) && key != 'id') {
                    const convertedValue = convertValueToEnglish(body[key]);
                    body[key] = (key == 'mobile') ? convertedValue : Number(convertedValue);
                }

            }


        }

        const copyReq = request.clone({
            body: body
        });

        return next.handle(copyReq);
    }

    allowed(url: string): boolean {
        const list = [
            "api/libraries/racks",
            "api/books",
            "api/books/items",
            "api/library/members",
            "api/libraries/cards",
            "api/asset/itemcodes"
        ];
        for (let i = 0; i < list.length; i++) {
            if (url.lastIndexOf(list[i]) != -1) {
                return true;
            }
        }
        return false
    }

    attributes() {
        const attributes = [
            'floorNo',
            "numberOfPage",
            "purchasePrice",
            "numberOfCopy",
            "mobile",
            "cardFee",
            "maxIssueCount",
            "lateFee",
            "minQuantity"
        ];

        return attributes;
    }

}