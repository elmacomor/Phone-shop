import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../proizvodi/MojConfig";
import {ProizvodGetAllVM} from "../proizvodi/ProizvodGetAllVM";
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-otvori-proizvode',
  templateUrl: './otvori-proizvode.component.html',
  styleUrls: ['./otvori-proizvode.component.css']
})
export class OtvoriProizvodeComponent implements OnInit {

  ProizvodID:any;
  ProizvodPodaci:any;
constructor(private httpClient: HttpClient, private router: ActivatedRoute) {}
  ngOnInit(): void {
   this.router.params.subscribe((a:any)=>{
     this.ProizvodID=+a["id"];
   });
    this.fetchPodatke();
 }
fetchPodatke(){
  this.httpClient.get(MojConfig.adresaServera+"/Proizvod/vratiProizvod?id="+this.ProizvodID).subscribe((a:any)=>{
    this.ProizvodPodaci=a;
  });
}
  GetSlikaBase64_fs(p:any){
    return "data:image/png;base64,"+p.slika_bajtovi;
  }


}
