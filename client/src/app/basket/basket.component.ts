import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket.service';
import { faPlusCircle, faMinusCircle, faTrash } from '@fortawesome/free-solid-svg-icons';
import { IBasketItem } from '../_models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  faPlusCircle = faPlusCircle; faMinusCircle = faMinusCircle; faTrash = faTrash;
  
  constructor(public basketService: BasketService) { }

  ngOnInit(): void {
  }

  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
}
