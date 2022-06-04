import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { OrderTotalsComponent } from './order-totals/order-totals.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    FontAwesomeModule,
    BreadcrumbModule,
  ],
  exports: [
    PaginationModule,
    FontAwesomeModule,
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
  ]
})
export class SharedModule { }
