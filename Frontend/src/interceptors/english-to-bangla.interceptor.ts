import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { toBengali } from 'src/services/utilities.service';


@Injectable()
export class EnglishToBanglaInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {

                    if (this.allowed(event.url) && event.body && event.body.data) {
                        toBengali(event.body.data);
                    }
                }
                return event
            })
        );
    }

    allowed(url: string): boolean {
        const list = [
            "api/libraries/counts",
            "api/hostels/rooms-and-beds"
        ];
        for (let i = 0; i < list.length; i++) {
            if (url.lastIndexOf(list[i]) != -1) {
                return true;
            }
        }
        return false
    }

}