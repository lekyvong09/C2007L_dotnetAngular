import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IBrand } from '../_models/brand';
import { IPagination } from '../_models/pagination';
import { IProduct } from '../_models/product';
import { IType } from '../_models/product-type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(pageNumber: number, pageSize: number, brandId?: number, typeId?: number, sort?: string, search?: string): Observable<IPagination | null> {
    let params = new HttpParams();

    if (brandId){
      params = params.append('brandId', brandId.toString());
    }
    
    if (typeId){
      params = params.append('typeId', typeId.toString());
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    if (search) {
      params = params.append('search', search);
    }

    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
        .pipe(
          map(response => {
            return response.body
          })
        );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(`${this.baseUrl}products/${id}`);
  }

  getBrands(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes(): Observable<IType[]> {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
