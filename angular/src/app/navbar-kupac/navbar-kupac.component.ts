import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-navbar-kupac',
  templateUrl: './navbar-kupac.component.html',
  styleUrls: ['./navbar-kupac.component.css']
})
export class NavbarKupacComponent implements OnInit {

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
  }
  logout() {
    this.auth.signOut();
  }
}
