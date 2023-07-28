import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  private role$ = new BehaviorSubject<string>("");
  constructor() { }

  public getRoleFromStore(){              //getter
    return this.role$.asObservable();
  }

  public setRoleForStore(role:string){    //setter
    this.role$.next(role);
  }

}
