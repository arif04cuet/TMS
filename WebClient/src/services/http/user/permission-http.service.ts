import { Injectable } from '@angular/core';
import { HttpService } from '../http.service';
import { SecurityService } from 'src/services/security.service';
import { AuthService } from 'src/services/auth.service';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { state } from 'src/constants/state';

@Injectable()
export class PermissionHttpService {

    constructor(
        private httpService: HttpService,
        private securityService: SecurityService
    ) {

    }

    public list(userId = 0) {
        return this.httpService.get(`permissions?userId=${userId}`);
    }

    public check(body) {
        return this.httpService.post(`permissions/check`, body);
    }

    getPermissions(): string[] {
        return this.securityService.getPermissions() || [];
    }

    isRouteGranted(modules: string | string[]) {
        // return true;
        let _permissions = []
        if (Array.isArray(modules)) {
            (<string[]>modules).forEach(m => {
                if (m[0] == '#') {
                    _permissions.push(m.substring(1));

                }
                else {
                    _permissions.push(`${m}.manage`, `${m}.list`);
                }
            });
        }
        else {
            if (modules[0] == '#') {
                _permissions.push(modules.substring(1));
            }
            else {
                _permissions = [`${modules}.manage`, `${modules}.list`];
            }
        }
        const cacheKey = _permissions.toString();

        let granted = false;
        if (state.permissionCache.hasOwnProperty(cacheKey)) {
            granted = state.permissionCache[cacheKey];

        }
        else {
            const permissions = this.getPermissions();
            granted = this.includes(permissions, _permissions);
            state.permissionCache[cacheKey] = granted;
        }
        return granted;
    }

    includes(permissions: string[], permissions2: string[]) {
        const r = permissions2.some(x => permissions.includes(x));
        return r;
    }

}

// used for loading permission before Angular app is bootstrapping.
export function permissionFactory(
    authService: AuthService,
    securityService: SecurityService,
    permissionService: PermissionHttpService
) {
    const userId = authService.getLoggedInUserId();
    if (/*false && */userId) {
        console.log('permission Factory');
        return () => permissionService.list(userId).pipe(
            map(res => {
                const permissions = extractPermissions(res);
                securityService.setPermissions(permissions);
            })
        ).toPromise();
    }
    return () => of(true).toPromise();
}

export function extractPermissions(res) {
    const permissions: string[] = []
    if (res.data.items) {
        res.data.items.forEach(item => {
            if (item.groups) {
                item.groups.forEach(group => {
                    if (group.permissions) {
                        group.permissions.forEach(permission => {
                            if (permission.granted) {
                                permissions.push(permission.code);
                            }
                        });
                    }
                });
            }
        });
    }
    return permissions;
}