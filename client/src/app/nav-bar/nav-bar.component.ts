import { Component, OnInit } from '@angular/core';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { BasketService } from '../basket/basket.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  /// FontAwesome icons
  faCartShopping = faCartShopping;
  constructor(public basketService: BasketService) { }

  ngOnInit(): void {
  }

}
