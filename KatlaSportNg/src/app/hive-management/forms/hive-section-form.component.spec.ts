import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HiveSectionFormComponent } from './hive-section-form.component';

describe('HiveSectionFormComponent', () => {
  let component: HiveSectionFormComponent;
  let fixture: ComponentFixture<HiveSectionFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
