import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../proizvodi/MojConfig";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-servisi-kupac',
  templateUrl: './servisi-kupac.component.html',
  styleUrls: ['./servisi-kupac.component.css']
})
export class ServisiKupacComponent implements OnInit {
  servisPodaci: any[]=[];

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.GetServisi();
  }

  GetServisi() {
    this.httpKlijent.get(MojConfig.adresaServera+"/Servis/GetServisi").subscribe((x:any)=>{
      this.servisPodaci = x;
    });
  }
  get_podaci() {
    return this.servisPodaci;
  }

}
