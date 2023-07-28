import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtvoriProizvodeComponent } from './otvori-proizvode.component';

describe('OtvoriProizvodeComponent', () => {
  let component: OtvoriProizvodeComponent;
  let fixture: ComponentFixture<OtvoriProizvodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OtvoriProizvodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OtvoriProizvodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
