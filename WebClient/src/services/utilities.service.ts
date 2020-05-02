import { environment } from 'src/environments/environment';

export function forEachObj(obj: any, fn: (k: any, v: any) => void) {
    for (const key in obj) {
        if (obj.hasOwnProperty(key)) {
            const value = obj[key];
            invoke(fn, key, value);
        }
    }
}

export function invoke(fn: Function, ...args) {
    if (fn) fn(...args);
}

export function clean(o) {
    const _o = {}
    for (const k in o) {
        if (o.hasOwnProperty(k)) {
            const v = o[k];
            if (Array.isArray(v)) {
                const arr = v.map(x => {
                    return clean(x);
                });
                _o[k] = arr;
            }
            else {
                if (v) {
                    _o[k] = v;
                }
            }
        }
    }
    return _o;
}

export function getLang() {
    const lang = environment.production ? 'bn' : 'en'
    return localStorage.getItem('otms_lang') || lang
}