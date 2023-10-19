import { TestBed } from '@angular/core/testing';

import { AeroportosService } from './aeroportos.service';

describe('AeroportosService', () => {
  let service: AeroportosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AeroportosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
