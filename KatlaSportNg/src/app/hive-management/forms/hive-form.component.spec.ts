import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HiveFormComponent } from './hive-form.component';

describe('HiveFormComponent', () => {
  let component: HiveFormComponent;
  let fixture: ComponentFixture<HiveFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
