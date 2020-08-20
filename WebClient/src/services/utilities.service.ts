import { environment } from 'src/environments/environment';
import { HttpEventType, HttpResponse } from '@angular/common/http';

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
    const lang = environment.production ? 'bn' : 'bn'
    return lang || localStorage.getItem('otms_lang');
}

export function createAnchorAndFireForDownload(blob: Blob, fileName: string) {
    const _event = document.createEvent('MouseEvent');
    _event.initEvent('click', false, false);
    const href = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.download = fileName;
    a.href = href;
    document.body.appendChild(a);
    a.dispatchEvent(_event);
    URL.revokeObjectURL(href);
    document.body.removeChild(a);
}

export function progress(event: any, progress, success) {
    if (event.type === HttpEventType.UploadProgress) {
        if (progress) {
            progress(Math.round(100 * event.loaded / event.total));
        }
    } else if (event instanceof HttpResponse) {
        if (success) {
            success(event.body);
        }
    } else if (event.type === HttpEventType.DownloadProgress) {
        if (progress) {
            progress(event.loaded);
        }
    }
}

export function buildUrl(url: string, ...args) {
    const _args = args.filter(x => x);
    const _url = `${url}?${_args.join('&')}`;
    return _url;
}