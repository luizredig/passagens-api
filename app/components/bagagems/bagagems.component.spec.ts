import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BagagemsComponent } from './bagagems.component';

describe('BagagemsComponent', () => {
  let component: BagagemsComponent;
  let fixture: ComponentFixture<BagagemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BagagemsComponent]
    });
    fixture = TestBed.createComponent(BagagemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
