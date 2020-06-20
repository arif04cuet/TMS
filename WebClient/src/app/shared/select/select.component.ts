import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html'
})
export class SelectComponent {

  @Input() label = '';
  @Output() onChange = new EventEmitter();
  @Input() labelKey = 'name';

  loading: boolean = false;
  items = [];

  private _value;

  private total: number = 0;
  private offset: number = 0;
  private limit: number = 20;
  private fetchFn: (pagination: string, search?: string) => Observable<Object>;
  private subscriptions = [];
  private _selectFirstOption = false;
  private _onLoadCompleted;

  get value() {
    return this._value;
  }

  set value(value) {
    this._value = value;
  }

  constructor() {
  }

  ngOnInit() {
  }

  register(fn: (pagination: string, search?: string) => Observable<Object>) {
    this.fetchFn = fn;
    return this;
  }

  fetch(search?: string, clearOnFetch = false) {
    if (this.fetchFn) {
      this.busy(true);
      const pagination = `offset=${this.offset}&limit=${this.limit}`;
      const subscription = this.fetchFn(pagination, search).subscribe(
        (res: any) => {
          const items = res.data.items || [];
          if (clearOnFetch) {
            this.items = [];
          }
          setTimeout(() => {
            this.items = [...this.items, ...items];
          }, 0)
          this.busy(false);
          if (this._selectFirstOption && this.items[0].length > 0) {
            this._value = this.items[0].id;
            // this.propagateChange(this._value);
          }
          if (this._onLoadCompleted) {
            this._onLoadCompleted();
          }
        },
        err => {
          this.busy(false);
        }
      );
      if (subscription) {
        this.subscriptions.push(subscription);
      }
    }
    return this;
  }

  fetchNext(search?: string) {
    this.offset = this.offset + this.limit;
    this.fetch(search);
  }

  selectFirstOption() {
    this._selectFirstOption = true;
    return this;
  }

  onValueChange(e) {
    if (this.onChange) {
      this.onChange.emit(e);
    }
  }

  onLoadCompleted(fn: () => void) {
    this._onLoadCompleted = fn;
    return this;
  }

  ngOnDestroy() {
    this.subscriptions.forEach(item => {
      item.unsubscribe();
    });
  }

  loadMore() {
    this.loading = true;
    this.fetchNext()
  }

  private busy(value) {
    setTimeout(() => this.loading = value, 0);
  }


}