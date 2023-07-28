import { Injectable } from '@angular/core';
import {HubConnection, HubConnectionBuilder} from "@aspnet/signalr";
import {MojConfig} from "./proizvodi/MojConfig";
import {environment} from "../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class MySignalRService {

  private hubKonekcija:HubConnection;
  constructor() {
    this.hubKonekcija=new HubConnectionBuilder()
      .withUrl(environment.signalRUrl).build();
    this.hubKonekcija.start();
  }


  public addListener=(callback:()=>void)=>{
    console.log("addListener");
    this.hubKonekcija.on('Poruka',callback);

    this.hubKonekcija.on('PosaljiPoruku',callback);
  }
  public  sendMessage=()=>{
    this.hubKonekcija.invoke('PosaljiPoruku')
      .catch(err=>console.error(err));
  }
}
