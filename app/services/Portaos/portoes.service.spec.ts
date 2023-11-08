import { TestBed } from '@angular/core/testing';

import { PortoesService } from './portoes.service';

describe('PortoesService', () => {
  let service: PortoesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PortoesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
