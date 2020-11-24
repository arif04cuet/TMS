import 'reflect-metadata';
import { convertValueToEnglish } from 'src/services/utilities.service';

const metadataKey = Symbol('otmsSearchable');

export function Searchable(serverFieldName: string, operator: string) {
    return function (target: Object, key: string) {
        const k = `${key}:${serverFieldName}:${operator}`
        registerProperty(target, k);
    }
}

function registerProperty(target: object, key: string): void {
    let keys: string[] = Reflect.getMetadata(metadataKey, target);
    if (keys) {
        keys.push(key);
    } else {
        keys = [key];
        Reflect.defineMetadata(metadataKey, keys, target);
    }
}

export function getSearchableProperties(origin: object): object {
    const keys: string[] = Reflect.getMetadata(metadataKey, origin);
    const result = [];
    if (keys && keys.length) {
        keys.forEach(key => {
            const arr = key.split(":");
            const property = arr[0];
            const value = origin[property] ? convertValueToEnglish(origin[property]) : origin[property];
            //const value = origin[property];
            if (value !== undefined && value !== null && value !== "") {
                result.push(`Search=${arr[1]} ${arr[2]} ${value}`);
            }
        });
    }
    return result;
}