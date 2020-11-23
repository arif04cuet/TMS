import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { toBengali } from 'src/services/utilities.service';
import { TranslateService } from '@ngx-translate/core';


@Injectable()
export class EnglishToBanglaInterceptor implements HttpInterceptor {

    private _translateService: TranslateService

    constructor(translateService: TranslateService) {
        this._translateService = translateService
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {

                    if (this.allowed(event.url) && event.body && event.body.data) {

                        toBengali(event.body.data, this._translateService);
                    }
                }
                return event
            })
        );
    }

    allowed(url: string): boolean {
        const list = [

            "api/users",
            "api/languages",
            "api/libraries/racks",
            "api/books/items",
            "api/libraries/cards/status",
            "api/books/status",
            "api/status",
            "api/asset/dashboard",
            "api/hostels/dashboard",
            "api/libraries/dashboard",
            "api/training/dashboard",
            "api/books/formats",
            "api/books",
            "api/library/members",
            "api/asset/itemcodes/categories/2",
            "api/courses",
            "api/asset/licenses",
            "api/asset/categories"
        ];

        var urlObj = new URL(url);

        if (list.findIndex(el => el == urlObj.pathname.substring(1)) != -1)
            return true;

        return false;

        // for (let i = 0; i < list.length; i++) {

        //     //var urlParts = url.split("?");
        //     //url = urlParts[0];
        //     var urlObj = new URL(url);
        //     if (url.lastIndexOf(list[i]) != -1) {
        //         return true;
        //     }
        // }
        // return false
    }

}