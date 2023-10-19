import { TestBed } from '@angular/core/testing';

import { BagagensService } from './bagagens.service';

describe('BagagensService', () => {
  let service: BagagensService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BagagensService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
