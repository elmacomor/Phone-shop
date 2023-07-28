import { TestBed } from '@angular/core/testing';

import { MySignalRService } from './my-signal-r.service';

describe('MySignalRService', () => {
  let service: MySignalRService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MySignalRService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
