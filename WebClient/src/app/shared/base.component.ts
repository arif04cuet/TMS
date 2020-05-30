import { Subscription, Observable } from 'rxjs';
import { on, broadcast, BROADCAST_KEYS } from 'src/services/broadcast.service';
import { AppInjector } from 'src/app/app.component';
import { Router, NavigationExtras, UrlTree, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { HttpService } from 'src/services/http/http.service';
import { TranslateService } from '@ngx-translate/core';
import { map } from 'rxjs/operators';
import { invoke, getLang, forEachObj } from 'src/services/utilities.service';
import { environment } from 'src/environments/environment';

export class BaseComponent {

    _subscriptions: Subscription[];
    _messageService: NzMessageService;
    _router: Router;
    _httpService: HttpService;
    _translate: TranslateService;
    _modalService: NzModalService
    breadcrumbs = [];

    protected _activatedRouteSnapshot: ActivatedRouteSnapshot

    constructor() {
        this._subscriptions = [];
        this._messageService = AppInjector.get(NzMessageService);
        this._router = AppInjector.get(Router);
        this._httpService = AppInjector.get(HttpService);
        this._translate = AppInjector.get(TranslateService);
        this._modalService = AppInjector.get(NzModalService);

    }

    subscribe<T>(
        observable: Observable<T>,
        next?: (value: T) => void,
        error?: (error: any) => void,
        complete?: () => void): void {
        const subscription = observable.subscribe(
            n => {
                this.invoke(next, n);
            },
            e => {
                this.invoke(error, e);
                this.invoke(complete);
                this.handleError(e);
                this.busy(false);
            },
            () => {
                this.busy(false);
                this.invoke(complete);
            }
        );
        this._subscriptions.push(subscription);
    }

    unsubscribe() {
        this._subscriptions.forEach(s => {
            s.unsubscribe();
        });
    }

    on<T>(key: string, fn: (value: T) => void): void {
        this.subscribe(on(key), fn);
    }

    broadcast(key: string, data?: any) {
        broadcast(key, data);
    }

    goTo(url: string | UrlTree, extras?: NavigationExtras) {
        this._router.navigateByUrl(url, extras)
    }

    invoke(fn: Function, ...args) {
        invoke(fn, ...args)
    }

    busy(init = true) {
        broadcast(BROADCAST_KEYS.LOADING, init);
    }

    handleError(error, redirect = '/login') {
        if (error && error.error) {
            if (error && error.status === 403) {
                this._messageService.error(error.error);
                this._router.navigateByUrl('/login');
            } else if (error.error.message) {
                if (error.error.message == "form_error") {

                }
                else {
                    this._messageService.error(error.error.message);
                }
            } else {
                this._messageService.error(error.message);
            }
        } else if (error && !error.ok) {
            this._messageService.error(error.message);
        }
    }

    getQueryParams(name: string) {
        return this._activatedRouteSnapshot.queryParams[name] || this._activatedRouteSnapshot.params[name];
    }

    constructObject(controls) {
        const obj = {}
        for (const key in controls) {
            if (controls.hasOwnProperty(key)) {
                const control = controls[key];
                const value = control.value;
                if (Array.isArray(value)) {
                    obj[key] = value.map(x => {
                        const o = {}
                        forEachObj(x, (k, v) => {
                            if (v !== null && v !== undefined) {
                                o[k] = v;
                            }
                        });
                        return o;
                    });
                }
                else {
                    if (value !== null && value !== undefined) {
                        obj[key] = control.value;
                    }
                }
            }
        }
        return obj;
    }

    setValues(controls, res, ignoreControls = []) {
        for (const key in res) {
            if (!ignoreControls.includes(key) && res.hasOwnProperty(key)) {
                const control = controls[key];
                if (control) {
                    const value = res[key];
                    if (Array.isArray(value)) {
                        control.setValue(value.map(x => x.id));
                    }
                    else if (typeof (value) === 'object') {
                        control.setValue(value?.id);
                    }
                    else {
                        control.setValue(value);
                    }
                }
            }
        }
    }

    error(key: string, interpolateParams?: Object) {
        return this._translate.get(key, interpolateParams).pipe(
            map(res => {
                return {
                    error: true,
                    message: res
                }
            })
        )
    }

    translate(key: string, onTranslate: (msg: string) => void) {
        this._translate.use(getLang());
        const s = this._translate.get(key).subscribe(x => this.invoke(onTranslate, x));
        this._subscriptions.push(s);
    }

    t(key: string, interpolateParams?: Object) {
        this._translate.use(getLang());
        return this._translate.get(key, interpolateParams).toPromise()
    }

    success(key: string) {
        this.translate(key, x => this._messageService.success(x));
    }

    failed(key: string) {
        this.translate(key, x => this._messageService.error(x));
    }

    warning(key: string) {
        this.translate(key, x => this._messageService.warning(x));
    }

    info(key: string) {
        this.translate(key, x => this._messageService.info(x));
    }

    requesting(key: string) {
        this.translate(key, x => this._messageService.loading(x));
    }

    log(...args) {
        if (!environment.production) {
            console.log(...args)
        }
    }

    buildBreadcrumbs() {
        let parent = this._activatedRouteSnapshot.parent;
        let arr = [];
        while (parent) {
            if (parent.url && parent.url.length > 0) {
                arr.push({
                    url: parent.url.map(x => x.path).join('/'),
                    icon: parent.data?.breadcrumb?.icon,
                    title: parent.data?.breadcrumb?.title,
                });
            }
            parent = parent.parent;
        }
        this.breadcrumbs = arr.reverse();
        let route = ''
        this.breadcrumbs = this.breadcrumbs.map((x, i) => {
            route += `/${x.url}`
            return { ...x, route: route, last: i == this.breadcrumbs.length - 1 };
        });
        setTimeout(() => this.broadcast('breadcrumbs', this.breadcrumbs));
    }

    snapshot(snapshot: ActivatedRouteSnapshot) {
        this._activatedRouteSnapshot = snapshot;
        this.buildBreadcrumbs();
    }

    ngOnDestroy() {
        this.unsubscribe();
        this.busy(false);
    }

}