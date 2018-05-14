import { TestBed, inject } from '@angular/core/testing';

import { HiveService } from './hive.service';

describe('HiveService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HiveService]
    });
  });

  it('should be created', inject([HiveService], (service: HiveService) => {
    expect(service).toBeTruthy();
  }));
});
