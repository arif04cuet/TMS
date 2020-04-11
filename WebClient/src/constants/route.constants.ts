export const USER_ROUTE = {
    ADD: `/admin/users/add`,
    EDIT: (id) => `/admin/users/${id}/edit`,
    VIEW: (id) => `/admin/users/${id}/view`
}

export interface IRoute {
    route: string;
    url: any;
    title: string;
    icon: string;
    iconStyle: string;
}