import { TestBed } from '@angular/core/testing';

import { PassageirosService } from './passageiros.service';

describe('PassageirosService', () => {
  let service: PassageirosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PassageirosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
