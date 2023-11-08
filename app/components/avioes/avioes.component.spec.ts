import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvioesComponent } from './avioes.component';

describe('AvioesComponent', () => {
  let component: AvioesComponent;
  let fixture: ComponentFixture<AvioesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AvioesComponent]
    });
    fixture = TestBed.createComponent(AvioesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
