import { BaseComponent } from './base.component';

export class TableComponent extends BaseComponent {

    loading: boolean = false;
    total: number = 0;
    pageIndex: number = 1;
    pageSize: number = 20;
    items = [];

    constructor() {
        super();
    }

    fill(response: any, items: any[] = null) {
        if (response && response.status == 200) {
            this.total = response.data.size;
            if (items == null) {
                this.items = response.data.items;
            }
        }
        this.loading = false;
    }

}