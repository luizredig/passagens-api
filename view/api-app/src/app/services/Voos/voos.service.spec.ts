import { TestBed } from '@angular/core/testing';

import { VoosService } from './voos.service';

describe('VoosService', () => {
  let service: VoosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VoosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
