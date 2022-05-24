import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/_models/product';
import { ShopService } from '../shop.service';
import { faPlusCircle, faMinusCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  /// Fontawesome icon
  faPlusCircle = faPlusCircle; faMinusCircle = faMinusCircle;

  product: IProduct | undefined;

  constructor(private activatedRoute: ActivatedRoute, private shopService: ShopService) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')!).subscribe(p => {
      this.product = p;
    }, error => console.log(error));
  }
}
