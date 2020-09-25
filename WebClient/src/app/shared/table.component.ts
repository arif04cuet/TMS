import { BaseComponent } from './base.component';
import { getSearchableProperties } from 'src/decorators/searchable.decorator';
import { Observable } from 'rxjs';
import { Type } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';

export class TableComponent extends BaseComponent {

    loading: boolean = true;
    total: number = 0;
    pageIndex: number = 1;
    pageSize: number = 100;
    items = [];
    additionalSearchTerm;

    service;
    onDeleted: (res: any) => void;
    onDeleteFailed: (res: any) => void;

    allChecked = false;
    setOfCheckedId = new Set<number>();
    indeterminate = false;
    listOfCurrentPageItems = [];
    rowItemDisabledFilterKey = "disabled";
    pageSizeOptions = [20, 100];

    private _fn: (pagination: string, search: string) => Observable<Object>;

    constructor(service) {
        super();
        this.service = service;
    }

    fill(response: any, items: any[] = null) {
        if (response && response.status == 200) {
            this.total = response.data.size;
            if (items == null) {
                if (!response.data.items && Array.isArray(response.data)) {
                    this.items = response.data;
                    this.total = response.data.length;
                }
                else {
                    this.items = response.data.items;
                }
            }
        }
        this.loading = false;
    }

    async delete(e) {
        const deletedText = await this.t('successfully.deleted')
        const deleteModal = this._modalService.confirm({
            nzTitle: await this.t('confirm'),
            nzContent: await this.t('do.you.want.to.delete'),
            nzOkText: await this.t('delete'),
            nzCancelText: await this.t('cancel'),
            nzOkLoading: false,
            nzClosable: false,
            nzOnOk: () => {
                deleteModal.getInstance().nzOkLoading = true;
                this.subscribe(this.service.delete(e.id),
                    res => {
                        deleteModal.getInstance().nzOkLoading = false;
                        this._messageService.create('success', deletedText);
                        this.invoke(this.onDeleted, res);
                        //refresh data
                        this.load();
                    },
                    err => {
                        deleteModal.getInstance().nzOkLoading = false;
                        this.invoke(this.onDeleteFailed, err);
                        this.log('err', err)
                    }
                );
            }
        });


    }

    getSearchTerms() {
        const searchableProperties: any = getSearchableProperties(this);
        if (searchableProperties) {
            return searchableProperties.join("&");
        }
        return "";
    }

    load(fn?: (pagination: string, search: string) => Observable<Object>) {
        this._fn = fn;
        let offset = 0;
        if (this.pageIndex > 1) {
            offset = (this.pageSize * this.pageIndex) - this.pageSize;
        }
        const pagination = `offset=${offset}&limit=${this.pageSize}`;
        let search = this.getSearchTerms();
        this.loading = true;
        let listFn;
        if (fn) {
            listFn = fn(pagination, search);
        }
        else if (this.service && this.service.list) {
            listFn = this.service.list(pagination, search);
        }
        if (listFn) {
            this.subscribe(listFn,
                (res: any) => {
                    this.fill(res);
                    this.loading = false;
                },
                err => {
                    console.log(err);
                    this.loading = false;
                }
            );
        }
    }

    pageIndexChanged(pageIndex) {
        this.pageIndex = pageIndex;
        this.load();
    }

    pageSizeChanged(pageSize) {
        this.pageSize = pageSize;
        this.load();
    }

    onAllChecked(checked: boolean): void {
        this.listOfCurrentPageItems.filter(x => !x[this.rowItemDisabledFilterKey]).forEach(({ id }) => this.updateCheckedSet(id, checked));
        this.refreshCheckedStatus();
    }

    onCurrentPageDataChange(listOfCurrentPageItems: []): void {
        this.listOfCurrentPageItems = listOfCurrentPageItems;
        this.refreshCheckedStatus();
    }

    refreshCheckedStatus(): void {
        const listOfEnabledData = this.listOfCurrentPageItems.filter(x => !x[this.rowItemDisabledFilterKey]);
        this.allChecked = listOfEnabledData.every(({ id }) => this.setOfCheckedId.has(id));
        this.indeterminate = listOfEnabledData.some(({ id }) => this.setOfCheckedId.has(id)) && !this.allChecked;
    }

    updateCheckedSet(id: number, checked: boolean): void {
        if (checked) {
            this.setOfCheckedId.add(id);
        } else {
            this.setOfCheckedId.delete(id);
        }
    }

    onItemChecked(id: number, checked: boolean): void {
        this.updateCheckedSet(id, checked);
        this.refreshCheckedStatus();
    }

    addModal<T>(component: Type<T>, modalService: NzModalService, params: any = {},) {
        const modal = modalService.create({
            nzWidth: '50%',
            nzContent: component,
            nzGetContainer: () => document.body,
            nzComponentParams: params,
            nzFooter: null
        });
        const s = modal.afterOpen.subscribe(() => {
            const componentInstance = (<any>modal.getContentComponent());
            componentInstance.modalInstance = modal.getInstance();
            componentInstance.id = params.id;
            componentInstance.onCheckMode = id => componentInstance.get(id);
            componentInstance.init();
        });
        const _fn = this._fn;
        const s2 = modal.afterClose.subscribe(x => {
            if(x === true) {
                this.load(_fn);
            }
        });
        this._subscriptions.push(...[s, s2]);
    }

}