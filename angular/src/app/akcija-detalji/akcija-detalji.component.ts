import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ProizvodGetAllVM} from "../proizvodi/ProizvodGetAllVM";
import {MojConfig} from "../proizvodi/MojConfig";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-akcija-detalji',
  templateUrl: './akcija-detalji.component.html',
  styleUrls: ['./akcija-detalji.component.css']
})
export class AkcijaDetaljiComponent implements OnInit {

  AkcijaID:any;
  Proizvodi:any=[];
  AkcijaProizvodi:any=[];

  NizProizvoda:any=[];
  constructor(private router:ActivatedRoute,private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.router.params.subscribe((a:any)=>{
      this.AkcijaID=+a["id"];
    });
    this.DobaviProizvode();
    this.GetProizvodiAkcije();
  }

  DobaviProizvode(){
    this.httpKlijent.get<ProizvodGetAllVM>(MojConfig.adresaServera+"/Proizvod/GetProizvodi").subscribe((x:any)=>{
      this.Proizvodi=x;
    });
  }

  GetProizvodiAkcije(){
    this.httpKlijent.get(MojConfig.adresaServera+"/ProizvodVikendAkcija/ProizvodAkcijaGetAll").subscribe((x:any)=>{
      this.AkcijaProizvodi=x;
    });
  }

GetProizvode(){//imam akcijaID imam listu proizvoda i imam listu svih proizvoda na svim akcijama
    this.NizProizvoda=[];
    for(let x of this.AkcijaProizvodi){
      if(x.vikendAkcijaID==this.AkcijaID){
        for(let p of this.Proizvodi){
          if(p.id==x.proizvodID){
            this.NizProizvoda.push(p);
          }
        }
      }
    }
    if(this.NizProizvoda==null){
      return[];
    }
    else{
      return this.NizProizvoda;
    }
}
  GetSlikaBase64Umanjena_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_umanjena;
  }

  Ukloni(x: any) {
    for(let a of this.AkcijaProizvodi){
      if(a.proizvodID==x.id&&a.vikendAkcijaID==this.AkcijaID){
        // @ts-ignore
        this.httpKlijent.post(MojConfig.adresaServera+"/ProizvodVikendAkcija/Obrisi?id="+a.id).subscribe((x:any)=>{
          this.GetProizvodiAkcije();
          this.GetProizvode();
        })
      }
    }
  }
}
