import { Pipe, PipeTransform, NgModule } from '@angular/core';
import * as moment from 'moment';

@Pipe({ name: 'momentDate' })
export class MomentPipe implements PipeTransform {
    transform(value: Date | moment.Moment): any {
        if(value) {
            return moment.utc(value).local().format('MMM D, YYYY, h:mm:ss A');
        }
        return '';
    }
}

@NgModule({
    declarations: [MomentPipe],
    exports: [MomentPipe],
    providers: [MomentPipe]
})
export class MomentPipeModule { }