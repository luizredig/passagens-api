import { TestBed } from '@angular/core/testing';

import { AvioesService } from './avioes.service';

describe('AvioesService', () => {
  let service: AvioesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvioesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
