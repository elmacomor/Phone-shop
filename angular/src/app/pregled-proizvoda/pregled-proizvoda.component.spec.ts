import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledProizvodaComponent } from './pregled-proizvoda.component';

describe('PregledProizvodaComponent', () => {
  let component: PregledProizvodaComponent;
  let fixture: ComponentFixture<PregledProizvodaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledProizvodaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledProizvodaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
