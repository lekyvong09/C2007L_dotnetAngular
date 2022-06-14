import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormTextInputComponent } from './form-text-input/form-text-input.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
    FormTextInputComponent,
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    FontAwesomeModule,
    BreadcrumbModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
  ],
  exports: [
    PaginationModule,
    FontAwesomeModule,
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent,
    OrderTotalsComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    FormTextInputComponent,
  ]
})
export class SharedModule { }
