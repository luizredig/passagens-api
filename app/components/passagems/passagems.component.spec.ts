import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassagemsComponent } from './passagems.component';

describe('PassagemsComponent', () => {
  let component: PassagemsComponent;
  let fixture: ComponentFixture<PassagemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PassagemsComponent]
    });
    fixture = TestBed.createComponent(PassagemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
