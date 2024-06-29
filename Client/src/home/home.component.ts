import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShoppingCartService } from 'src/services/shopping-cart.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userName:any;

  constructor(
    private userService: UserService,
    private router: Router,
    private shoppingCartService: ShoppingCartService
  ) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.userService.getUserName().subscribe(
        (res: string) => {
          this.userName = res; // Setează userName cu răspunsul primit
          this.shoppingCartService.createFirstShoppingCartByUsername(this.userName).subscribe();
        },
        error => {
          console.error('Error fetching username:', error);
        }
      );
    }
  }
}
