import { Pipe, PipeTransform } from '@angular/core';
import { convertDateToBengali } from 'src/services/utilities.service';
@Pipe({
    name: 'banglaDate'
})
export class BanglaDatePipe implements PipeTransform {

    transform(date: any): unknown {
        const banglaDate = convertDateToBengali(date);
        return banglaDate;
    }

}
