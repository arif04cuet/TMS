import { Directive, Input, HostListener } from '@angular/core';
import { getNumberMap } from 'src/services/utilities.service';

@Directive({
    selector: '[enToBn]'
})
export class EnToBnDirective {

    @HostListener('keypress', ['$event'])
    onKeyUp(event: KeyboardEvent) {
        const map = getNumberMap();
        const converted = map[event.key];
        const e = <any>event
        if(converted) {
            e.target.value = e.target.value + converted;
            event.preventDefault();
            event.stopPropagation();
        }
    }
}
