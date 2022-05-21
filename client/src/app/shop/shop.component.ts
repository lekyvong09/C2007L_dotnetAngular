import { Component, OnInit } from '@angular/core';
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
  /// fontawesome icon
  faSearch = faSearch; faRefresh = faRefresh;

  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IType[] = [];

  brandIdSelected: number = 0;
  typeIdSelected: number = 0;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(): void {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe(response => {
      console.log(response);
      this.products = response!.data;
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
    this.getProducts();
  }

  onProductTypeSelect(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }
}
