import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './_models/pagination';
import { IProduct } from './_models/product';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Book shop';
  products: IProduct[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
     this.http.get<IPagination>('https://localhost:5001/api/products').subscribe(
       (response: IPagination) => {
         console.log(response);
         this.products = response.data;
       }, error => {
         console.log(error);
       }
     );
  }



}
