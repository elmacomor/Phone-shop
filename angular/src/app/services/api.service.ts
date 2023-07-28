import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private BaseUrl: string = 'https://localhost:7093/Autentifikacija/'
  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<any>(`${this.BaseUrl}GetUsers`);
  }
}
