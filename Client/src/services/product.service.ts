import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    constructor(
      private fb:FormBuilder,
      private http:HttpClient,
      private router:Router
    ) {

     }

     readonly BaseURI = 'http://localhost:5098/api';

     getProductsList()
     {
       return this.http.get(this.BaseURI+'/Product/GetProducts');
     }
}
