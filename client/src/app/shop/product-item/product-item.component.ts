import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/_models/product';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  /// fontawesome icon
  faCartShopping = faCartShopping;
  
  @Input() product: IProduct | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
