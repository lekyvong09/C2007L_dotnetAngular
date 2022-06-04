import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem } from '../_models/basket';
import { IProduct } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;

  /**
   * Purpose: to save observable variable as a session variable
   */
  private basketSource = new BehaviorSubject<IBasket>({id: '', items: []});
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          console.log(this.getCurrentBasketValue());
        })
      );
  }

  setBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe((response:IBasket) => {
      this.basketSource.next(response);
      console.log(response);
    }, error => console.log(error));
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    var itemToAdd: IBasketItem = {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity: quantity,
      brand: item.productBrand,
      type: item.productType
    };

    /// if basket doesn't exist, create new one
    var basket: IBasket = (!this.getCurrentBasketValue() || this.getCurrentBasketValue().id === '') ? this.createNewBasket() : this.getCurrentBasketValue();

    /// check if item doesn't exist, add new item. Else just increase the quantity.
    var index = basket.items.findIndex(i => i.id === itemToAdd.id);

    if (index === -1) {
      itemToAdd.quantity = quantity;
      basket.items.push(itemToAdd);
    } else {
      basket.items[index].quantity += quantity;
    }

    this.setBasket(basket);
  }

  private createNewBasket(): IBasket {
    const basket = new Basket();
    /// save basket_id to local storage
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }
}
