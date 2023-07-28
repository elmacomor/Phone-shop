import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "./MojConfig";
import {ProizvodGetAllVM} from "./ProizvodGetAllVM";
import {AuthService} from "../services/auth.service";
import {Location} from "@angular/common";
import {MySignalRService} from "../my-signal-r.service";

@Component({
  selector: 'app-proizvodi',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})
export class ProizvodiComponent implements OnInit {

 proizvodPodaci:ProizvodGetAllVM[]=[];
 noviProizvod?:ProizvodGetAllVM | null;
 tipProizvodaPodaci:any;
 prikaziCb:boolean=false;
 pretraga:string='';
 checkedProducts:any=[];
 VikendAkcija:any;
 NizAkcijaCmb:any=[];

 OdabranaAkcijaID:any;
 prikaziModalDialog:boolean=false;
  Akcije:any=[];
  ProizvodiAkcije:any=[];

  constructor(private httpKlijent: HttpClient,private location:Location,private mySignalRservice:MySignalRService) {

  }

  ngOnInit(): void {
    this.DobaviProizvode();
    this.DobaviTipove();
    this.GetAkcijeZaCmb();
    this.GetAkcije();
    this.GetProizvodiAkcije();
    this.mySignalRservice.addListener(()=>{
      console.log("poruka1");
      this.DobaviProizvode();
    })
  }
  DobaviProizvode(){
    this.httpKlijent.get<ProizvodGetAllVM>(MojConfig.adresaServera+"/Proizvod/GetProizvodi").subscribe((x:any)=>{
      this.proizvodPodaci=x;});
  }

  GetProizvodi() {
    if (this.proizvodPodaci == null)
      return [];

    let filteredProizvodi = this.proizvodPodaci.filter((p: any) =>
      p.marka.toLowerCase().startsWith(this.pretraga.toLowerCase())
    );
    return filteredProizvodi;
  }
    DobaviTipove(){
    this.httpKlijent.get(MojConfig.adresaServera+"/ProizvodiTip/GetProizvodiTip").subscribe(x=>this.tipProizvodaPodaci=x);
  }


 SnimiProizvode(){
    this.httpKlijent.post(MojConfig.adresaServera+"/Proizvod/Snimi",this.noviProizvod).subscribe(x=>{
      this.DobaviProizvode();
      this.noviProizvod=null;
    });
 }
 GetSlikaBase64Umanjena_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_umanjena;
 }
  GetSlikaBase64_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_bajtovi;
  }
 noviProizvod_dugme(){
    this.noviProizvod={
      id:0,
      marka:"",
      cijena:100,
      slika_bajtovi:"",
      boja:"",
      specifikacije:"",
      proizvodTipID:1,
      proizvodTipNaziv:"",
      kratakOpisProizvoda:""
    }
 }
 generisi_preview(){
   // @ts-ignore
   var file = document.getElementById("slika-input").files[0];
   if (file) {
     var reader = new FileReader();
     let this2=this;
     reader.onload = function () {
       this2.noviProizvod!.slika_bajtovi = reader.result?.toString();
     }

     // @ts-ignore
     reader.readAsDataURL(file);
   }
 }


  OnCheckboxChanged(x: any) {
    const index=this.checkedProducts.indexOf(x.id);
    if(index==-1){
      this.checkedProducts.push(x.id);
    }
  else{
    this.checkedProducts.splice(index,1);
    }
  }

  OtkaziAkciju() {
    this.Ocisti();
    this.prikaziCb=false;
  }

  Ocisti(){
    this.checkedProducts.splice(0,this.checkedProducts.length);
  }
  VikendAkcijaInicijaliziraj(){
    this.VikendAkcija={
      id:0,
      od:new Date(),
      do:new Date(),
      iznosPopusta:0,
    }
  }
  DodajAkciju() {
      this.httpKlijent.post(MojConfig.adresaServera+"/VikendAkcija/Snimi",this.VikendAkcija).subscribe((a:any)=>{
          this.VikendAkcija=null;
          this.GetAkcijeZaCmb();
          this.GetAkcije();
      });
  }
  GetAkcijeZaCmb(){
    this.httpKlijent.get(MojConfig.adresaServera+"/VikendAkcija/VikendAkcijaGetAllForCmb").subscribe((x:any)=>{
      this.NizAkcijaCmb=x;
    })
  }

  DodajProizvodAkcija() {
    for(let x of this.checkedProducts){
      let proizvodAkcija={
        id:0,
        vikendAkcijaID:this.OdabranaAkcijaID,
        proizvodID:x,
      }
      this.httpKlijent.post(MojConfig.adresaServera+"/ProizvodVikendAkcija/Snimi",proizvodAkcija).subscribe((x:any)=>{

      });
    }
    this.prikaziModalDialog=false;
    this.prikaziCb=false;
    this.GetAkcije();
    this.GetProizvodiAkcije();
  }

  GetIznosAkcije(x: any) {
    const trenutniDatum=Date.now();
    for(let p of this.ProizvodiAkcije){
      if(p.proizvodID==x.id){
        for(let a of this.Akcije){

          if(p.vikendAkcijaID==a.id){
            const DatumAkcije=new Date(a.do);
            if(DatumAkcije.getTime()>trenutniDatum)
              return a.iznosPopusta;
          }
        }
      }
    }
    return 0;
  }
  GetAkcije(){
    this.httpKlijent.get(MojConfig.adresaServera+"/VikendAkcija/AkcijeGetAlll").subscribe((x:any)=>{
      this.Akcije=x;
    });
  }

  GetProizvodiAkcije(){
    this.httpKlijent.get(MojConfig.adresaServera+"/ProizvodVikendAkcija/ProizvodAkcijaGetAll").subscribe((x:any)=>{
      this.ProizvodiAkcije=x;
    });
  }

  nijeNaAkciji(x:any) {
    const TrenutniDatum=Date.now();
      for(let p of this.ProizvodiAkcije){
        if(p.proizvodID==x.id){
          for(let a of this.Akcije) {
            if(a.id==p.vikendAkcijaID){
            const DatumAkcije = new Date(a.do);
            if(DatumAkcije.getTime()>TrenutniDatum){
              return false;
            }
            }
          }
        }
      }
      return true;
  }
}
