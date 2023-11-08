import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoosComponent } from './voos.component';

describe('VoosComponent', () => {
  let component: VoosComponent;
  let fixture: ComponentFixture<VoosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VoosComponent]
    });
    fixture = TestBed.createComponent(VoosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
