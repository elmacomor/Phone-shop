import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {MyProfileServiceService} from "../my-profile-service.service";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../proizvodi/MojConfig";
import {ApiService} from "../services/api.service";
import {UserStoreService} from "../services/user-store.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-moj-profil',
  templateUrl: './moj-profil.component.html',
  styleUrls: ['./moj-profil.component.css']
})
export class MojProfilComponent implements OnInit {
  public users: any = [];
  public role!:string;
  ime: string;
  prezime: string;
  username: string;
  email: string;
  editMode = false;

  constructor(private httpKlijent: HttpClient,private myService: MyProfileServiceService, private api: ApiService, private auth: AuthService, private userStore: UserStoreService, private router: Router) {
    this.ime = '';
    this.prezime = '';
    this.email = '';
    this.username = '';
  }

  ngOnInit(): void {
    this.api.getUsers().subscribe(x=>{
      this.users = x;
    });

    this.userStore.getRoleFromStore().subscribe(x=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = x || roleFromToken;
    })

    /*if(this.role == 'uposlenik')
      this.router.navigate(['/proizvodi']);*/

    this.DobaviPodatke();
  }

  DobaviPodatke() {
    this.myService.getProfile().subscribe((data: any) => {
      this.ime = data.ime;
      this.prezime = data.prezime;
      this.username = data.username;
      this.email = data.email;
    });
  }

  onEditClick() {
    this.editMode = !this.editMode;
  }

  onSaveClick() {
    this.httpKlijent.put(MojConfig.adresaServera+"/Kupac/UpdateKorisnik", {ime:this.ime, prezime:this.prezime}).subscribe((data: any) => {
      this.editMode = false;
    });
  }
}
