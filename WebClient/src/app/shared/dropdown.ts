import { Observable } from 'rxjs';
import { AbstractControl } from '@angular/forms';

export class Dropdown {

    loading: boolean = true;
    items = [];

    private total: number = 0;
    private offset: number = 0;
    private limit: number = 20;
    private subscriptions = [];
    private control: AbstractControl;
    private _selectFirstOption;
    private firstFetch = true;

    constructor(fn?: (pagination) => Observable<Object>) {
        this.fetch(fn);
    }

    fetch(fn: (pagination) => Observable<Object>) {
        if(fn) {
            this.loading = true;
            const _pagination = `offset=${this.offset}&limit=${this.limit}`;
            const subscription = fn(_pagination).subscribe(
                (res: any) => {
                    this.items = res.data.items || [];
                    this.loading = false;
                    if (this.firstFetch && this._selectFirstOption) {
                        this.selectFirstOption(this._selectFirstOption);
                    }
                    this.firstFetch = false;
                },
                err => {
                    this.loading = false;
                }
            );
            if(subscription) {
                this.subscriptions.push(subscription);
            }
        }
    }

    setControl(control: AbstractControl) {
        this.control = control;
        return this;
    }

    selectFirstOption(propertyKey?: string, condition?: () => boolean) {
        this._selectFirstOption = propertyKey || 'id';
        const hasCondition = condition !== null && condition !== undefined
        const conditionResult = condition && condition();
        if ((!hasCondition || conditionResult) && this.items.length > 0) {
            this.control.setValue(this.items[0][propertyKey]);
        }
        return this;
    }

    dispose() {
        this.subscriptions.forEach(item => {
            item.unsubscribe();
        });
    }

}