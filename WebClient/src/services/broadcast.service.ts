import { Injectable, NgZone } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { AppInjector } from 'src/app/app.component';

@Injectable()
export class BroadcastService {

    private _event: Subject<BroadcastEvent>;

    constructor(private zone: NgZone) {
        this._event = new Subject<BroadcastEvent>();
    }

    on<T>(key: string): Observable<T> {
        return this._event.asObservable().pipe(
            filter(event => event.key === key),
            map(event => <T>event.data)
        );
    }

    broadcast(key: any, data?: any) {
        // this.zone.runOutsideAngular(() => {
        this._event.next(<BroadcastEvent>{ key, data });
        // });
    }

}

export const BROADCAST_KEYS = {
    UPDATED_USER_PROFILE: 'UPDATED_USER_PROFILE',
    LOADING: 'LOADING',
};

export interface BroadcastEvent {
    key: any;
    data?: any;
}

export const on = <T>(key: string): Observable<T> => {
    return AppInjector.get(BroadcastService).on(key);
}

export const broadcast = (key: any, data?: any) => {
    return AppInjector.get(BroadcastService).broadcast(key, data);
}
