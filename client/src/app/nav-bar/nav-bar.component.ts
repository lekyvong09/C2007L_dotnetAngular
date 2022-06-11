import { Component, OnInit } from '@angular/core';
import { faCartShopping, faShoppingCart, faHistory, faSignOut } from '@fortawesome/free-solid-svg-icons';
import { AccountService } from '../account/account.service';
import { BasketService } from '../basket/basket.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  /// FontAwesome icons
  faCartShopping = faCartShopping; faShoppingCart = faShoppingCart; faHistory = faHistory; faSignOut = faSignOut;
  
  constructor(public basketService: BasketService, public accountService: AccountService) { }

  ngOnInit(): void {
  }

  logout() {
    this.accountService.logout();
  }
}
