import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HiveSectionListComponent } from './hive-section-list.component';

describe('HiveSectionListComponent', () => {
  let component: HiveSectionListComponent;
  let fixture: ComponentFixture<HiveSectionListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
