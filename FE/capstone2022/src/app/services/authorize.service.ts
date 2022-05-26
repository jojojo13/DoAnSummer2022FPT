import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/Account';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  constructor(private _http:HttpClient) { }

  signIn(account:Account){
    return this._http.post('http://localhost:8080/api/signin',account)
  }
}
