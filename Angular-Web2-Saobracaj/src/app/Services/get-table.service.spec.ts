import { TestBed } from '@angular/core/testing';

import { GetTableService } from './get-table.service';

describe('GetTableService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetTableService = TestBed.get(GetTableService);
    expect(service).toBeTruthy();
  });
});
