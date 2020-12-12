import { Pipe, PipeTransform } from '@angular/core';
import { convertValueToBengali } from 'src/services/utilities.service';
@Pipe({
  name: 'bangla'
})
export class BanglaPipe implements PipeTransform {

  transform(number: any): unknown {
    console.log(number);
    return convertValueToBengali(number);
  }

}
