import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-navbar-uposlenik',
  templateUrl: './navbar-uposlenik.component.html',
  styleUrls: ['./navbar-uposlenik.component.css']
})
export class NavbarUposlenikComponent implements OnInit {

  constructor(private auth : AuthService) { }

  ngOnInit(): void {
  }

  logout() {
    this.auth.signOut();
  }
}
