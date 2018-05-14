import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { ProductCategoryProductListItem } from '../models/product-category-product-list-item';
import { ProductListItem } from '../models/product-list-item';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = environment.apiUrl + 'api/products/';
  private categoryUrl = environment.apiUrl + 'api/categories/';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Array<ProductListItem>> {
    return this.http.get<Array<ProductListItem>>(this.url);
  }

  getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.url}${productId}`);
  }

  getCategoryProducts(productCategoryId: number): Observable<Array<ProductCategoryProductListItem>> {
    return this.http.get<Array<ProductCategoryProductListItem>>(`${this.categoryUrl}${productCategoryId}/products`);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.url}`, product);
  }

  updateProduct(product: Product): Observable<Object> {
    return this.http.put<Object>(`${this.url}${product.id}`, product);
  }

  deleteProduct(productId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${productId}`);
  }
}
