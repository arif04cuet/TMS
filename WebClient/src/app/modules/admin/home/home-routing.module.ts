import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'users',
        loadChildren: () => import('../user/user/list/user-list.module').then(x => x.UserListModule),
        data: {
          name: 'user_list',
          breadcrumb: {
            icon: 'team',
            title: 'users'
          }
        }
      },
      {
        path: 'roles',
        loadChildren: () => import('../user/role/list/role-list.module').then(x => x.RoleListModule),
        data: {
          name: 'role_list',
          breadcrumb: {
            icon: 'safety',
            title: 'roles'
          }
        }
      },
      {
        path: 'designations',
        loadChildren: () => import('../user/designation/list/designation-list.module').then(x => x.DesignationListModule),
        data: {
          name: 'designation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'designations'
          }
        }
      },
      {
        path: 'departments',
        loadChildren: () => import('../user/department/list/department-list.module').then(x => x.DepartmentListModule),
        data: {
          name: 'department_list',
          breadcrumb: {
            icon: 'safety',
            title: 'departments'
          }
        }
      },
      {
        path: 'profile',
        loadChildren: () => import('../user/profile/view/profile-view.module').then(x => x.ProfileViewModule),
        data: {
          name: 'profile_view',
          breadcrumb: {
            icon: 'safety',
            title: 'profile'
          }
        }
      },
      {
        path: 'libraries',
        loadChildren: () => import('../library/library/list/library-list.module').then(x => x.LibraryListModule),
        data: {
          name: 'library_list',
          breadcrumb: {
            icon: 'safety',
            title: 'libraries'
          }
        }
      },
      {
        path: 'library/members',
        loadChildren: () => import('../library/member/list/member-list.module').then(x => x.MemberListModule),
        data: {
          name: 'library_member_list',
          breadcrumb: {
            icon: 'safety',
            title: 'members'
          }
        }
      },
      {
        path: 'library/cards',
        loadChildren: () => import('../library/card/list/card-list.module').then(x => x.CardListModule),
        data: {
          name: 'library_card_list',
          breadcrumb: {
            icon: 'safety',
            title: 'cards'
          }
        }
      },
      {
        path: 'library/books',
        loadChildren: () => import('../library/book/list/book-list.module').then(x => x.BookListModule),
        data: {
          name: 'book_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books'
          }
        }
      },
      {
        path: 'library/books/items',
        loadChildren: () => import('../library/book-item/list/book-item-list.module').then(x => x.BookItemListModule),
        data: {
          name: 'book_item_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books'
          }
        }
      },
      {
        path: 'library/racks',
        loadChildren: () => import('../library/rack/list/rack-list.module').then(x => x.RackListModule),
        data: {
          name: 'rack_list',
          breadcrumb: {
            icon: 'safety',
            title: 'racks'
          }
        }
      },
      {
        path: 'library/authors',
        loadChildren: () => import('../library/author/list/author-list.module').then(x => x.AuthorListModule),
        data: {
          name: 'author_list',
          breadcrumb: {
            icon: 'safety',
            title: 'authors'
          }
        }
      },
      {
        path: 'library/publishers',
        loadChildren: () => import('../library/publisher/list/publisher-list.module').then(x => x.PublisherListModule),
        data: {
          name: 'publisher_list',
          breadcrumb: {
            icon: 'safety',
            title: 'publishers'
          }
        }
      },
      {
        path: 'library/categories',
        loadChildren: () => import('../library/subject/list/subject-list.module').then(x => x.SubjectListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'categories'
          }
        }
      },
      {
        path: 'asset/vendors',
        loadChildren: () => import('../asset/vendors/list/vendor-list.module').then(x => x.VendorListModule),
        data: {
          name: 'vendor_list',
          breadcrumb: {
            icon: 'safety',
            title: 'vendors'
          }
        }
      },
      {
        path: 'asset/suppliers',
        loadChildren: () => import('../asset/supplier/list/supplier-list.module').then(x => x.SupplierListModule),
        data: {
          name: 'supplier_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Suppliers'
          }
        }
      },
      {
        path: 'asset/depreciations',
        loadChildren: () => import('../asset/depreciation/list/depreciation-list.module').then(x => x.DepreciationListModule),
        data: {
          name: 'depreciation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Depreciations'
          }
        }
      },
      {
        path: 'asset/locations',
        loadChildren: () => import('../asset/location/list/location-list.module').then(x => x.LocationListModule),
        data: {
          name: 'location_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Locations'
          }
        }
      },
      {
        path: 'asset/manufacturers',
        loadChildren: () => import('../asset/manufacturer/list/manufacturer-list.module').then(x => x.ManufacturerListModule),
        data: {
          name: 'manufacturer_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Manufacturers'
          }
        }
      },
      {
        path: 'asset/statuses',
        loadChildren: () => import('../asset/status/list/status-list.module').then(x => x.StatusListModule),
        data: {
          name: 'status_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Statuses'
          }
        }
      },
      {
        path: 'asset/categories',
        loadChildren: () => import('../asset/category/list/category-list.module').then(x => x.CategoryListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Categories'
          }
        }
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
