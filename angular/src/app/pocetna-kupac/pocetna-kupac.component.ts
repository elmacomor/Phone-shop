import { Component, OnInit } from '@angular/core';
import {ApiService} from "../services/api.service";
import {AuthService} from "../services/auth.service";
import {UserStoreService} from "../services/user-store.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pocetna-kupac',
  templateUrl: './pocetna-kupac.component.html',
  styleUrls: ['./pocetna-kupac.component.css']
})
export class PocetnaKupacComponent implements OnInit {
  public users: any = [];
  public role!:string;

  constructor(private api: ApiService, private auth: AuthService, private userStore: UserStoreService, private router: Router) {
  }

  ngOnInit():void {
    this.api.getUsers().subscribe(x=>{
      this.users = x;
    });

    this.userStore.getRoleFromStore().subscribe(x=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = x || roleFromToken;
    })

    if(this.role == 'uposlenik')
      this.router.navigate(['/proizvodi']);
  }


}
