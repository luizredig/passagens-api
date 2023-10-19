import { TestBed } from '@angular/core/testing';

import { CompanhiaAereasService } from './companhias-aereas.service';

describe('CompanhiaAereasService', () => {
  let service: CompanhiaAereasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanhiaAereasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
