import { Payment } from './../models/payment-and-orders';
import { Cart } from './../models/cart';
import { Product } from './../models/product';
import { User } from './../models/user';
import { NavigationService } from './navigation.service';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UtilityService {
  changeCart = new Subject();
  constructor(
    private NavigationService: NavigationService,
    private jwt: JwtHelperService
  ) {}

  applyDiscount(price: number, discount: number): number {
    let finalPrice: number = price - price * (discount / 100);
    return finalPrice;
  }

  // JWT Helper Service : npm install @auth0/angular-jwt
  getUser(): User {
    let token = this.jwt.decodeToken();
    let user: User = {
      id: token.id,
      firstName: token.firstName,
      lastName: token.lastName,
      address: token.address,
      mobile: token.mobile,
      email: token.email,
      password: '',
      createdAt: token.createdAt,
      modifiedAt: token.modifiedAt,
    };
    return user;
  }
  setUser(token: string) {
    localStorage.setItem('user', token);
  }

  isLoggedIn() {
    return localStorage.getItem('user') ? true : false;
  }

  logoutUser() {
    localStorage.removeItem('user');
  }
  addToCart(product: Product) {
    let productId = product.id;
    let userId = this.getUser().id;

    this.NavigationService.addToCart(userId, productId).subscribe((res) => {
      if (res.toString() === 'inserted') this.changeCart.next(1);
    });
  }

  calculatePayment(cart: Cart, payment: Payment) {
    payment.totalAmount = 0;
    payment.amountPaid = 0;
    payment.amountReduced = 0;

    for (let cartitem of cart.cartItems) {
      payment.totalAmount += cartitem.product.price; //ราคาสินค้าทั้งหมด
      payment.amountReduced +=
        cartitem.product.price -
        this.applyDiscount(
          cartitem.product.price,
          cartitem.product.offer.discount
        ); //ส่วนลด
      payment.amountPaid += this.applyDiscount(
        cartitem.product.price,
        cartitem.product.offer.discount
      ); //ราคาทั้งหมด
    }
    if (payment.amountPaid > 50000) payment.shippingCharges = 2000;
    else if (payment.amountPaid > 20000) payment.shippingCharges = 1000;
    else if (payment.amountPaid > 5000) payment.shippingCharges = 500;
    else payment.shippingCharges = 200; //ค่าจัดส่ง
  }

  calculatePricePaid(cart: Cart) {
    let pricePaid = 0;
    for (let cartitem of cart.cartItems) {
      pricePaid += this.applyDiscount(
        cartitem.product.price,
        cartitem.product.offer.discount
      );
    }
    return pricePaid;
  }
}
