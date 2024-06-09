import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeModule } from 'src/home/home.module';
import { NavbarComponent } from 'src/navbar/navbar.component';
import { FooterComponent } from 'src/footer/footer.component';
import { UserModule } from 'src/user/user.module';
import { UserService } from 'src/services/user.service';
import { RegisterComponent } from 'src/user/register/register.component';
import { ProductsListComponent } from '../product/products-list/products-list.component';
import { ProductModule } from 'src/product/product.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ShoppingCartModule } from 'src/shopping-cart/shopping-cart.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HomeModule,
    UserModule,
    HttpClientModule,
    ProductModule,
    FontAwesomeModule,
    ShoppingCartModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
