import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HiveSectionProductListComponent } from './hive-section-product-list.component';

describe('HiveSectionProductListComponent', () => {
  let component: HiveSectionProductListComponent;
  let fixture: ComponentFixture<HiveSectionProductListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionProductListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
