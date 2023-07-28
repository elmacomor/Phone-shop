import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServisiComponent } from './servisi.component';

describe('ServisiComponent', () => {
  let component: ServisiComponent;
  let fixture: ComponentFixture<ServisiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServisiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServisiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
