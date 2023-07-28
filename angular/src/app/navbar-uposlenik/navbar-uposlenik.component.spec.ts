import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarUposlenikComponent } from './navbar-uposlenik.component';

describe('NavbarUposlenikComponent', () => {
  let component: NavbarUposlenikComponent;
  let fixture: ComponentFixture<NavbarUposlenikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavbarUposlenikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarUposlenikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
