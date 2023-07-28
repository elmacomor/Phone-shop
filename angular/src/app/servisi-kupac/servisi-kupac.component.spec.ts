import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServisiKupacComponent } from './servisi-kupac.component';

describe('ServisiKupacComponent', () => {
  let component: ServisiKupacComponent;
  let fixture: ComponentFixture<ServisiKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServisiKupacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServisiKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
