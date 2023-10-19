import { TestBed } from '@angular/core/testing';

import { PagamentosService } from './pagamentos.service';

describe('PagamentosService', () => {
  let service: PagamentosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PagamentosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
