import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledAkcijaComponent } from './pregled-akcija.component';

describe('PregledAkcijaComponent', () => {
  let component: PregledAkcijaComponent;
  let fixture: ComponentFixture<PregledAkcijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledAkcijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledAkcijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
