import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCategoryProductListComponent } from './product-category-product-list.component';

describe('ProductCategoryProductListComponent', () => {
  let component: ProductCategoryProductListComponent;
  let fixture: ComponentFixture<ProductCategoryProductListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductCategoryProductListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCategoryProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
