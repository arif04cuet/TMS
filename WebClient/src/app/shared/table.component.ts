import { BaseComponent } from './base.component';
import { getSearchableProperties } from 'src/decorators/searchable.decorator';

export class TableComponent extends BaseComponent {

    loading: boolean = true;
    total: number = 0;
    pageIndex: number = 1;
    pageSize: number = 20;
    items = [];
    additionalSearchTerm;

    service;
    onDeleted: (res: any) => void;
    onDeleteFailed: (res: any) => void;

    constructor(service) {
        super();
        this.service = service;
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

    load(e?) {
        let offset = 0;
        if(this.pageIndex > 1) {
            offset = (this.pageSize * this.pageIndex) - this.pageSize;
        }
        const pagination = `offset=${offset}&limit=${this.pageSize}`;
        let search = this.getSearchTerms();
        this.loading = true;
        this.subscribe(this.service.list(pagination, search),
            (res: any) => {
                this.fill(res);
            },
            err => {
                console.log(err);
                this.loading = false;
            }
        );
    }

    pageIndexChanged(pageIndex) {
        this.pageIndex = pageIndex;
        this.load();
    }

    pageSizeChanged(pageSize) {
        this.pageSize = pageSize;
        this.load();
    }

}