import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "./proizvodi/MojConfig";

@Injectable({
  providedIn: 'root'
})
export class MyProfileServiceService {



  constructor(private http: HttpClient) { }

  getProfile() {
    return this.http.get(MojConfig.adresaServera+"/Autentifikacija/GetProfil");
  }
}
