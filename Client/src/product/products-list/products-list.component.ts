import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/services/product.service';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  faCartShopping = faCartShopping;

  productsList: any;
  userName: string = "";
  shoppingCartId: string = "";


  constructor(
    private service:ProductService,
    private router:Router,
    private userService:UserService
  ) { }

  ngOnInit(){
    this.service.getProductsList().subscribe(
      (res:any)=>{
        this.productsList=res;
      console.log(this.productsList);
      }
    )

    if (localStorage.getItem('token') != null) {
      this.userService.getUserName().subscribe(
        (res: string) => {
          this.userName = res; // Setează userName cu răspunsul primit
          this.userService.getShoppingCartIdByUserName(this.userName).subscribe(
            (res:string) =>{
                this.shoppingCartId = res;
            }
          );
        },
        error => {
          console.error('Error fetching username:', error);
        }
      );
    }
  }

  getProductsList(){
    this.service.getProductsList().subscribe(
      (res:any)=>{
        this.productsList=res;})
  }

  getProductsListByCategoryId(categoryId:any){
    this.service.getProductsListByCategoryId(categoryId).subscribe(
      (res:any)=>{
        this.productsList=res;})
  }

  addProductInShoppingCart()
  {
    
  }
}
