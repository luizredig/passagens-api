import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PortaosComponent } from './portaos.component';

describe('PortaosComponent', () => {
  let component: PortaosComponent;
  let fixture: ComponentFixture<PortaosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PortaosComponent]
    });
    fixture = TestBed.createComponent(PortaosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
