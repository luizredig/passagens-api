import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanhiaAereasComponent } from './companhia-aereas.component';

describe('CompanhiaAereasComponent', () => {
  let component: CompanhiaAereasComponent;
  let fixture: ComponentFixture<CompanhiaAereasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompanhiaAereasComponent]
    });
    fixture = TestBed.createComponent(CompanhiaAereasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
