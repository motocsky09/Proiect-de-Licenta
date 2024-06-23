import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShoppingCartService } from 'src/services/shopping-cart.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  constructor(
    private userService: UserService,
    private router:Router,
    private shoppingCartService: ShoppingCartService
  ){ }

  ngOnInit(){
    if (localStorage.getItem('token') != null)
    {
      console.log(this.userService.userName)
      this.shoppingCartService.createFirstShoppingCartByUsername(this.userService.userName).subscribe();
    } 
  }
}
