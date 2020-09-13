import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';
import { map, switchMap } from 'rxjs/operators';
import { SecurityService } from './security.service';
import { PermissionHttpService, extractPermissions } from './http/user/permission-http.service';

@Injectable()
export class AuthService {

    public storage: Storage = localStorage;
    public redirectUrl: string;

    constructor(
        private httpService: HttpService,
        private securityService: SecurityService,
        private permissionService: PermissionHttpService
    ) { }

    public init(): void {

    }

    public login(body) {
        return this.httpService.post('token', body).pipe(
            map((res: any) => {
                const data = res.data;
                data.remember = body.remember || false;
                this.securityService.setAuthData(res.data);
                return res;
            }),
            switchMap((res2: any) => {
                if (res2 && res2.data && res2.data.userId) {
                    return this.permissionService.list(res2.data.userId).pipe(
                        map(x => {
                            const permissions = extractPermissions(x);
                            console.log('login permissions', permissions);
                            this.securityService.setPermissions(permissions);
                            return res2;
                        })
                    )
                }
                return res2;
            })
        );
    }

    public reLogin() {
        const data = this.securityService.getAuthData();
        const body = data ? {
            accessToken: data.accessToken,
            refreshToken: data.refreshToken
        } : {};
        return this.httpService.post('token/refresh', body).pipe(
            map((res: any) => {
                const remember = this.isRemember();
                res.data.remember = remember;
                this.securityService.setAuthData(res.data);
                return res;
            })
        );
    }

    public forgotPassword(body) {
        return this.httpService.post('token/forgot-password', body);
    }

    public resetPassword(body) {
        return this.httpService.post('token/reset-password', body);
    }

    public logout() {
        this.securityService.removeAuthData();
        this.securityService.removePermissions();
    }

    public isAuthenticated(): boolean {
        const data = this.securityService.getAuthData();
        return data != null;
    }

    public getLoggedInUserInfo() {
        const data: any = this.securityService.getAuthData();
        return data?.userInfo;
    }

    public getLoggedInUserId() {
        const data: any = this.securityService.getAuthData();
        return data?.userId;
    }

    public isRemember() {
        const data: any = this.securityService.getAuthData();
        return data?.remember || false;
    }

}
