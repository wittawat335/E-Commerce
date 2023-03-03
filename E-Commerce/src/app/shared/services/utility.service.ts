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
}
