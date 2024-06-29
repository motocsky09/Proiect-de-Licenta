import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(
    private fb:FormBuilder,
    private http:HttpClient,
    private router:Router
  ) {

   }

   readonly BaseURI = 'http://localhost:5098/api';

   createFirstShoppingCartByUsername(userName:string)
   {
    let body = new HttpParams({
      fromObject : {
        'userName' : userName
      }
    })
     return this.http.post(this.BaseURI+'/ShoppingCart/CreateFirstShoppingCartByUsername?userName=' + userName,body);
   }
}
