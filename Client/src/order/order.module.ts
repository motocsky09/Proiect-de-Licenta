import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order.component';
import { ConfirmOrderComponent } from './confirm-order/confirm-order.component';


@NgModule({
  declarations: [OrderComponent, ConfirmOrderComponent],
  imports: [
    CommonModule,
    OrderRoutingModule
  ]
})
export class OrderModule { }
