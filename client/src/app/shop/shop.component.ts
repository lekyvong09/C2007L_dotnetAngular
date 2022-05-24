import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../_models/product';
import { ShopService } from './shop.service';

import {faSearch, faRefresh} from '@fortawesome/free-solid-svg-icons';
import { IBrand } from '../_models/brand';
import { IType } from '../_models/product-type';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  /**
   * {static: true} means we don't use *ngIf
   * {static: false} means we use *ngIf
   */
  @ViewChild('search', {static: true}) searchElement: ElementRef | undefined;

  /// fontawesome icon
  faSearch = faSearch; faRefresh = faRefresh;

  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IType[] = [];

  brandIdSelected: number = 0;
  typeIdSelected: number = 0;
  sortSelected = 'name';
  pageNumber = 1;
  pageSize = 3;
  totalCount = 0;
  search= '';

  sortOptions = [
    {name: 'Alphabetical', value:'name'},
    {name: 'Price: Low to High', value:'priceAsc'},
    {name: 'Price: High to Low', value:'priceDesc'},
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(): void {
    this.shopService.getProducts(this.pageNumber, this.pageSize, this.brandIdSelected, this.typeIdSelected, this.sortSelected, this.search)
          .subscribe(response => {
      // console.log(response);
      this.products = response!.data;
      this.pageNumber = response!.pageNumber;
      this.pageSize = response!.pageSize;
      this.totalCount = response!.totalCount;
    }, error => {
      console.log(error);
    });
  }

  getBrands(): void {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => console.log(error));
  }

  getTypes(): void {
    this.shopService.getTypes().subscribe(response => {
      this.productTypes = [{id: 0 , name: 'All'}, ...response];
    }, error => console.log(error));
  }

  onBrandSelect(brandId: number) {
    this.brandIdSelected = brandId;
    this.pageNumber = 1;
    this.getProducts();
  }

  onProductTypeSelect(typeId: number) {
    this.typeIdSelected = typeId;
    this.pageNumber = 1;
    this.getProducts();
  }

  onSortSelect(event: Event) {
    this.sortSelected = (<HTMLSelectElement>event.target).value;
    this.pageNumber = 1;
    this.getProducts();
  }

  onPageChange(event: any) {
    this.pageNumber = event;
    this.getProducts();
  }

  onSearch() {
    this.search = this.searchElement?.nativeElement.value;
    this.getProducts();
  }

  onReset() {
    this.searchElement!.nativeElement.value = '';
    this.brandIdSelected = 0;
    this.typeIdSelected = 0;
    this.sortSelected = 'name';
    this.pageNumber = 1;
    this.pageSize = 3;
    this.totalCount = 0;
    this.search = '';
    this.getProducts();
  }
}
