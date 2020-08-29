import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    private retry = 0;
    private maxRetry = 3;

    constructor(
        private authService: AuthService,
        private httpClient: HttpClient,
        private router: Router
    ) {

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    this.retry = 0;
                    if (!environment.production) {
                        // console.log('event ->>>', event);
                    }
                }
                return event
            }),
            catchError((err: HttpErrorResponse) => {
                if (!environment.production) {
                    console.log('error ->>>', err);
                }
                if (err.status == 401) {
                    // unauthorize
                    if (this.retry < this.maxRetry) {
                        this.retry++;
                        const remember = this.authService.isRemember()
                        if (remember) {
                            return this.authService.reLogin().pipe(
                                switchMap(res => {
                                    return this.httpClient.request(request)
                                }),
                                catchError((err2: any) => {
                                    if (!environment.production) {
                                        console.log('re login error ->>>', err);
                                    }
                                    this.authService.logout();
                                    this.router.navigateByUrl('/login');
                                    return throwError(err2);
                                })
                            );
                        }
                        else {
                            this.authService.logout();
                            this.router.navigateByUrl('/login');
                        }
                    }
                }
                return throwError(err);
            })
        );
    }

}