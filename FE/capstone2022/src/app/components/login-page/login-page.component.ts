import { Account } from './../../models/Account';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthorizeService } from 'src/app/services/authorize.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  loginForm:FormGroup
  account:Account
  msg=''
  constructor(private fb:FormBuilder,private auth:AuthorizeService) { 
    this.loginForm=this.fb.group({
      username:['',[Validators.required,Validators.minLength(8)]],
      password:['',[Validators.minLength(8),Validators.required]]
    })
    
    this.account=new Account();
  }

  ngOnInit(): void {
    
  }
  signIn(){
    this.account=this.loginForm.value
    console.log(this.loginForm)
    this.auth.signIn(this.account).subscribe(data=>{
      console.log(data)
      alert('da dang nhap thanh cong')
    },err=>{
      if(err.status==400){
        this.msg="Email is exsisted, pls use another email"
      }
      if(err.status==500){
        this.msg="Something wrong from server!!!"
      }
      
    })
  }

}
