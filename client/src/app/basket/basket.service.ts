import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../_models/basket';
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
  private basketTotalSource = new BehaviorSubject<IBasketTotals>({shipping: 0, subtotal: 0, total: 0});
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          // console.log(this.getCurrentBasketValue());
          this.calculateTotals();
        })
      );
  }

  setBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe((response:IBasket) => {
      this.basketSource.next(response);
      // console.log(response);
      this.calculateTotals();
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

  incrementItemQuantity(item: IBasketItem) {
    let basket = this.getCurrentBasketValue();
    let index = basket.items.findIndex(x => x.id === item.id);
    basket.items[index].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    let basket = this.getCurrentBasketValue();
    let index = basket.items.findIndex(x => x.id === item.id);
    if (basket.items[index].quantity > 1) {
      basket.items[index].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {
    let basket = this.getCurrentBasketValue();
    if (basket.items.some(x => x.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0 ) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next({id:'', items:[]});
      this.basketTotalSource.next({shipping: 0, subtotal: 0, total: 0});
      localStorage.removeItem('basket_id');
    }, error => console.log(error));
  }

  private createNewBasket(): IBasket {
    const basket = new Basket();
    /// save basket_id to local storage
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }


  private calculateTotals() {
    let basket = this.getCurrentBasketValue();
    let shipping = 0;
    let subtotal = basket.items.reduce((result, item) => (item.price * item.quantity) + result, 0);
    let total = subtotal + shipping;
    this.basketTotalSource.next({shipping: shipping, subtotal: subtotal, total: total});
  }
}
