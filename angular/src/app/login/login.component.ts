import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../services/auth.service";
import {Router} from "@angular/router";
import {UserStoreService} from "../services/user-store.service";

//import {AuthService} from "../auth.service";
//import ValidateForm from 'src/app/validateform';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string ="fa-eye-slash";

  loginForm!:FormGroup;
  constructor(private fb: FormBuilder, private auth:AuthService, private router: Router, private userStore: UserStoreService) { }

  ngOnInit(): void {
    this.loginForm=this.fb.group({
      username:['',Validators.required],
      password:['',Validators.required]
    })
  }

  hideShowPassword() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onLogin() {
    if(this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.auth.signIn(this.loginForm.value).subscribe({
        next:(x)=>{
          console.log(x.message);
          this.loginForm.reset();
          this.auth.storeToken(x.token);
          const tokenPayload = this.auth.decodeToken();
          this.userStore.setRoleForStore(tokenPayload.role);
          alert("Uspješan login !")
          this.router.navigate(['pocetna-kupac'])
        },
        error:(err)=>{
          alert("Došlo je do greške !")
          console.log(err);
        },
      });
    }else{
      this.validateAllFormFields(this.loginForm);
      alert("Your form is invalid")
    }
  }

  private validateAllFormFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }else if(control instanceof FormGroup){
        this.validateAllFormFields(control);
      }
    })
  }

}
