import { Payment } from './../shared/models/payment-and-orders';
import { Cart, CartItem } from './../shared/models/cart';
import { NavigationService } from './../shared/services/navigation.service';
import { UtilityService } from './../shared/services/utility.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  usersCart: Cart = {
    id: 0,
    user: this.UtilityService.getUser(),
    cartItems: [],
    ordered: false,
    orderedOn: '',
  };

  usersPaymentInfo: Payment = {
    id: 0,
    user: this.UtilityService.getUser(),
    paymentMethod: {
      id: 0,
      type: '',
      provider: '',
      available: false,
      reason: '',
    },
    totalAmount: 0,
    shippingCharges: 0,
    amountReduced: 0,
    amountPaid: 0,
    createdAt: '',
  };
  usersPreviousCarts: Cart[] = [];

  constructor(
    public UtilityService: UtilityService,
    private NavigationService: NavigationService
  ) {}
  ngOnInit(): void {
    //Get Cart
    this.NavigationService.getActiveCartOfUser(
      this.UtilityService.getUser().id
    ).subscribe((res: any) => {
      this.usersCart = res;

      //Calculate Payment
      this.UtilityService.calculatePayment(
        this.usersCart,
        this.usersPaymentInfo
      );
    });
    //Get Previous Carts
    this.NavigationService.getAllPreviousCarts(
      this.UtilityService.getUser().id
    ).subscribe((res: any) => {
      this.usersPreviousCarts = res;
      console.log(this.usersPreviousCarts);
    });
  }
}
