import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AeroportosComponent } from './aeroportos.component';

describe('AeroportosComponent', () => {
  let component: AeroportosComponent;
  let fixture: ComponentFixture<AeroportosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AeroportosComponent]
    });
    fixture = TestBed.createComponent(AeroportosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
