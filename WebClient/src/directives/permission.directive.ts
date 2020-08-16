import { Directive, TemplateRef, ViewContainerRef, Input } from '@angular/core';
import { PermissionHttpService } from 'src/services/http/user/permission-http.service';
import { state } from 'src/constants/state';

@Directive({
    selector: '[checkPermission]'
})
export class CheckPermissionDirective {

    private hasView = false;

    @Input() set checkPermission(permissions: string | string[]) {
        let condition = false;
        const cacheKey = permissions.toString();
        if (state.permissionCache.hasOwnProperty(cacheKey)) {
            condition = state.permissionCache[cacheKey];
        }
        else {
            const _permissions = this.permissionService.getPermissions();
            if (Array.isArray(permissions)) {
                condition = permissions.some(x => _permissions.includes(x));
            }
            else {
                condition = _permissions.includes(permissions);
            }
            state.permissionCache[cacheKey] = condition;
        }

        if (condition && !this.hasView) {
            this.viewContainer.createEmbeddedView(this.templateRef);
            this.hasView = true;
        } else if (condition && this.hasView) {
            this.viewContainer.clear();
            this.hasView = false;
        }
    }

    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private permissionService: PermissionHttpService
    ) { }
}
