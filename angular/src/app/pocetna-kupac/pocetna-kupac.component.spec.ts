import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PocetnaKupacComponent } from './pocetna-kupac.component';

describe('PocetnaKupacComponent', () => {
  let component: PocetnaKupacComponent;
  let fixture: ComponentFixture<PocetnaKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PocetnaKupacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PocetnaKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
