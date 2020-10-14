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
    const lang = environment.production ? 'bn' : 'bn'
    return /*localStorage.getItem('otms_lang') ||*/ lang
}

export function toBengali(obj) {
    for (const key in obj) {
        if (obj.hasOwnProperty(key)) {
            if (!Array.isArray(obj[key])) {
                convertPropertyToBengali(obj, key);
            }
            else {
                for (let i = 0; i < obj[key].length; i++) {
                    toBengali(obj[key][i]);
                }
            }
        }
    }
    return obj;
}
export function convertBookFormatToBangla(obj) {

}


export function convertPropertyToBengali(obj, key) {
    if (!["id", "offset", "limit", "size"].includes(key)) {
        console.log(obj[key]);
        if (typeof (obj[key]) == "number" || /^\d+$/.test(obj[key])) {
            const v = convertValueToBengali(obj[key].toString());
            obj[key] = v;
        }
        else if (typeof (obj[key]) == "object") {
            toBengali(obj[key])

        }
    }
}

export function convertValueToBengali(value: any) {
    value = value.toString()
    const map = getNumberMap();
    const len = value.length;
    let bengaliNumber = ""
    for (let i = 0; i < len; i++) {
        const l = map[value[i]];
        if (l) {
            bengaliNumber += l;
        }
        else {
            bengaliNumber += value[i];
        }
    }
    return bengaliNumber;
}

export function getNumberMap() {
    return {
        '0': '০',
        '1': '১',
        '2': '২',
        '3': '৩',
        '4': '৪',
        '5': '৫',
        '6': '৬',
        '7': '৭',
        '8': '৮',
        '9': '৯'
    }
}