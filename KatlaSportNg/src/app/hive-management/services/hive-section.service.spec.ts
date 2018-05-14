import { TestBed, inject } from '@angular/core/testing';

import { HiveSectionService } from './hive-section.service';

describe('HiveSectionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HiveSectionService]
    });
  });

  it('should be created', inject([HiveSectionService], (service: HiveSectionService) => {
    expect(service).toBeTruthy();
  }));
});
