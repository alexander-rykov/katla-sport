import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductCategory } from '../models/product-category';
import { ProductCategoryService } from '../services/product-category.service';

@Component({
  selector: 'app-product-category-form',
  templateUrl: './product-category-form.component.html',
  styleUrls: ['./product-category-form.component.css']
})
export class ProductCategoryFormComponent implements OnInit {

  productCategory = new ProductCategory(0, "My New Category", "CATE1", "Category description", false, "");
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productCategoryService: ProductCategoryService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.productCategoryService.getProductCategory(p['id']).subscribe(c => this.productCategory = c);
      this.existed = true;
    });
  }

  navigateToCategories() {
    this.router.navigate(['/categories']);
  }

  onCancel() {
    this.navigateToCategories();
  }

  onSubmit() {
    if (this.existed) {
      this.productCategoryService.updateProductCategory(this.productCategory).subscribe(c => this.navigateToCategories());
    } else {
      this.productCategoryService.addProductCategory(this.productCategory).subscribe(c => this.navigateToCategories());
    }
  }

  onDelete() {
    this.productCategoryService.setProductCategoryStatus(this.productCategory.id, true).subscribe(c => this.productCategory.isDeleted = true);
  }

  onUndelete() {
    this.productCategoryService.setProductCategoryStatus(this.productCategory.id, false).subscribe(c => this.productCategory.isDeleted = false);
  }

  onPurge() {
    this.productCategoryService.deleteProductCategory(this.productCategory.id).subscribe(c => this.navigateToCategories());
  }
}
