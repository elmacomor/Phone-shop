import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AkcijaDetaljiComponent } from './akcija-detalji.component';

describe('AkcijaDetaljiComponent', () => {
  let component: AkcijaDetaljiComponent;
  let fixture: ComponentFixture<AkcijaDetaljiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AkcijaDetaljiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AkcijaDetaljiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
