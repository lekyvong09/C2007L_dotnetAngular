import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    FontAwesomeModule,
    ToastrModule.forRoot(),
    BreadcrumbModule,
  ],
  exports: [
    PaginationModule,
    FontAwesomeModule,
    PagingHeaderComponent,
    PagerComponent,
    SectionHeaderComponent,
  ]
})
export class SharedModule { }
