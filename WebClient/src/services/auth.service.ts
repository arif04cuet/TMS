import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';
import { map, switchMap } from 'rxjs/operators';
import { SecurityService } from './security.service';
import { PermissionHttpService, extractPermissions } from './http/user/permission-http.service';
import { state } from 'src/constants/state';

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
                this.securityService.setAuthData(res.data);
                return res;
            }),
            switchMap((res2: any) => {
                return this.permissionService.list(res2.data.userId).pipe(
                    map(x => {
                        const permissions = extractPermissions(x);
                        console.log('login permissions', permissions);
                        this.securityService.setPermissions(permissions);
                        return res2;
                    })
                )
            })
        );
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

}
