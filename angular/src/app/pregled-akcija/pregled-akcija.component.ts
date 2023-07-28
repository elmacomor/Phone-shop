import {Component, NgModule, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../proizvodi/MojConfig";
import {DatePipe} from "@angular/common";
import {Router} from "@angular/router";


@Component({
  selector: 'app-pregled-akcija',
  templateUrl: './pregled-akcija.component.html',
  styleUrls: ['./pregled-akcija.component.css']
})
export class PregledAkcijaComponent implements OnInit {

  Akcije:any=[];
  constructor(private httpKlijent:HttpClient,private datePipe:DatePipe,private router:Router) { }

  ngOnInit(): void {
    this.GetAkcije();
  }
  GetAkcije(){
    this.httpKlijent.get(MojConfig.adresaServera+"/VikendAkcija/AkcijeGetAlll").subscribe((x:any)=>{
      this.Akcije=x;
    });
  }

  IsteklaAkcija(x:any) {
    const trenutniDatum=Date.now();
    const DatumIstekaAkcije=new Date(x.do);
    if(DatumIstekaAkcije.getTime()>trenutniDatum)
      return false;
    else
      return true;
  }

  VratiDatum(x:any) {
    const datum=new Date(x);
    return this.datePipe.transform(datum,'dd.MM.yyy')||'';
  }

  PregledajAkciju(x: any) {
    this.router.navigate(["akcija-detalji",x.id]);
  }

  saljiMail() {
    // @ts-ignore
    this.httpKlijent.post(MojConfig.adresaServera+"/VikendAkcija/SendEmail").subscribe(
      (response) => {
        alert("Success");
      },
      (error) => {
        console.log(error);
        alert("Error sending email.");
      }
    )
  }

}
