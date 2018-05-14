import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductCategoryProductListItem } from '../models/product-category-product-list-item';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-category-product-list',
  templateUrl: './product-category-product-list.component.html',
  styleUrls: ['./product-category-product-list.component.css']
})
export class ProductCategoryProductListComponent implements OnInit {

  categoryId: number;
  products: ProductCategoryProductListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.categoryId = p['id'];
      this.productService.getCategoryProducts(p['id']).subscribe(p => this.products = p);
    });
  }
}
