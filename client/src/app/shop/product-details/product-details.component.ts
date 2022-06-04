import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/_models/product';
import { ShopService } from '../shop.service';
import { faPlusCircle, faMinusCircle } from '@fortawesome/free-solid-svg-icons';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  /// Fontawesome icon
  faPlusCircle = faPlusCircle; faMinusCircle = faMinusCircle;

  product: IProduct | undefined;
  quantity = 1;

  constructor(private activatedRoute: ActivatedRoute, 
            private shopService: ShopService, 
            private breadcrumbService: BreadcrumbService,
            private basketService: BasketService) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')!).subscribe(p => {
      this.product = p;
      this.breadcrumbService.set('@productDetails', p.name);
    }, error => console.log(error));
  }


  addItemToBasket() {
    if (this.product) {
      this.basketService.addItemToBasket(this.product, this.quantity);
    }
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }
}
