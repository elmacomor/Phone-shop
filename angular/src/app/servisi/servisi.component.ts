import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {HttpClient} from "@angular/common/http";
import {ProizvodGetAllVM} from "../proizvodi/ProizvodGetAllVM";
import {MojConfig} from "../proizvodi/MojConfig";

@Component({
  selector: 'app-servisi',
  templateUrl: './servisi.component.html',
  styleUrls: ['./servisi.component.css']
})
export class ServisiComponent implements OnInit {
  servisPodaci: any[]=[];
  gradoviPodaci: any[]=[];
  noviServis: any;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.GetServisi();
    this.getGradovi();
  }



  private GetServisi() {
    this.httpKlijent.get(MojConfig.adresaServera+"/Servis/GetServisi").subscribe((x:any)=>{
      this.servisPodaci = x;
    });
  }

  private getGradovi() {
    this.httpKlijent.get(MojConfig.adresaServera+"/Grad/GetAll").subscribe((x:any)=>{
      this.gradoviPodaci = x;
    });
  }

  get_podaci() {
    return this.servisPodaci;
  }

  dodajServis() {
      this.httpKlijent.post(MojConfig.adresaServera+"/Servis/Snimi", this.noviServis).subscribe((x:any)=>{
        this.GetServisi();
        this.noviServis=null;
      });
  }

  noviServis_dugme() {
    this.noviServis={
      id:0,
      nazivServisa:"",
      brojTelefona:"",
      gradID:1,
      nazivGrada:"",
      cijena:10
    }
  }

  obrisiServis(x:any) {
    this.httpKlijent.post(MojConfig.adresaServera+"/Servis/Delete",x).subscribe((x:any)=>{
      this.GetServisi();
    });
  }
}
