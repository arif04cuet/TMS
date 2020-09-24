import { ActivatedRouteSnapshot } from '@angular/router';
import { FormBaseComponent } from './form-base.component';

export class FormComponent extends FormBaseComponent {

    constructor() {
        super();
    }

    ngOnInit(snapshot: ActivatedRouteSnapshot) {
        this.snapshot(snapshot);
        this.init();
    }

}
