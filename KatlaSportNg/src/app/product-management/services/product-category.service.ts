import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ProductCategory } from '../models/product-category';
import { ProductCategoryListItem } from '../models/product-category-list-item';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  private url = environment.apiUrl + 'api/categories/';

  constructor(private http: HttpClient) { }

  getProductCategories(): Observable<Array<ProductCategoryListItem>> {
    return this.http.get<Array<ProductCategoryListItem>>(this.url);
  }

  getProductCategory(productCategoryId: number): Observable<ProductCategory> {
    return this.http.get<ProductCategory>(`${this.url}${productCategoryId}`);
  }

  addProductCategory(productCategory: ProductCategory): Observable<ProductCategory> {
    return this.http.post<ProductCategory>(this.url, productCategory);
  }

  updateProductCategory(productCategory: ProductCategory): Observable<ProductCategory> {
    return this.http.put<ProductCategory>(`${this.url}${productCategory.id}`, productCategory);
  }

  deleteProductCategory(productCategoryId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${productCategoryId}`);
  }

  setProductCategoryStatus(productCategoryId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put<Object>(`${this.url}${productCategoryId}/status/${deletedStatus}`, null);
  }
}
