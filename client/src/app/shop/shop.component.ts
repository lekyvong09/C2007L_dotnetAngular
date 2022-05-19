import { Component, OnInit } from '@angular/core';
import { IProduct } from '../_models/product';
import { ShopService } from './shop.service';

import {faSearch, faRefresh} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  /// fontawesome icon
  faSearch = faSearch; faRefresh = faRefresh;

  products: IProduct[] = [];
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.shopService.getProducts().subscribe(response => {
      console.log(response);
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }

}
