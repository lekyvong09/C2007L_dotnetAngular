import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { IPagination } from './_models/pagination';
import { IProduct } from './_models/product';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Book shop';

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    /// auto load basket_id whenever customer visit back our website
    var basketId = localStorage.getItem('basket_id');

    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('basket is initialized');
      }, error => console.log(error));
    }
  }


}
