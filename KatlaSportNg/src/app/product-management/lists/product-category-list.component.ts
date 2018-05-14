import { Component, OnInit } from '@angular/core';
import { ProductCategoryListItem } from '../models/product-category-list-item';
import { ProductCategoryService } from '../services/product-category.service';

@Component({
  selector: 'app-product-category-list',
  templateUrl: './product-category-list.component.html',
  styleUrls: ['./product-category-list.component.css']
})
export class ProductCategoryListComponent implements OnInit {

  selectedProductCategory: ProductCategoryListItem;
  productCategories: ProductCategoryListItem[];

  constructor(private productCategoryService: ProductCategoryService) { }

  ngOnInit() {
    this.getProductCategories();
  }

  onSelect(productCategory: ProductCategoryListItem): void {
    this.selectedProductCategory = productCategory;
  }

  getProductCategories(): void {
    this.productCategoryService.getProductCategories().subscribe(c => this.productCategories = c);
  }

  enableProductCategory(): void {
  }

  disableProductCategory(): void {
  }
}
