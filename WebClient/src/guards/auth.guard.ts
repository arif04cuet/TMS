import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivate, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/services/auth.service';
import { PermissionHttpService } from 'src/services/http/user/permission-http.service';
import { state } from 'src/constants/state';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

    constructor(
        private router: Router,
        private authService: AuthService,
        private permissionService: PermissionHttpService
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.check(route);
    }

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this.check(childRoute);
    }

    private check(route: ActivatedRouteSnapshot): boolean | Observable<boolean> {
        const authenticated = this.authService.isAuthenticated();
        if (!authenticated) {
            this.router.navigateByUrl('/');
            return false;
        }
        let _route = route;
        while (_route.firstChild) {
            _route = _route.firstChild;
        }
        const permissions = _route.data?.permissions;
        if (route.component && permissions && permissions.length > 0) {
            let granted = false;
            const cacheKey = permissions.toString();
            if (state.permissionCache.hasOwnProperty(cacheKey)) {
                granted = state.permissionCache[cacheKey];
            }
            else {
                const permittedPermissions = this.permissionService.getPermissions();
                granted = this.permissionService.includes(permittedPermissions, permissions);
                state.permissionCache[cacheKey] = granted;
            }
            if (!granted) {
                this.router.navigateByUrl('/access-denied');
            }
            return granted;
        }
        else {
            return authenticated;
        }
    }

}