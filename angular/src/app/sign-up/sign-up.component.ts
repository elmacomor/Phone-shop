import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string ="fa-eye-slash";

  signUpForm!:FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.signUpForm=this.fb.group({
      ime:['',Validators.required],
      prezime:['',Validators.required],
      email:['',Validators.required],
      username:['',Validators.required],
      password:['',Validators.required]
    })
  }

  hideShowPassword() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onSignUp() {
    if(this.signUpForm.valid){
      this.auth.signUp(this.signUpForm.value).subscribe({
        next:(x=>{
          alert(x.message);
          this.signUpForm.reset();
          this.router.navigate(['login']);
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })
    }else{
      this.validateAllFormFields(this.signUpForm);
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
