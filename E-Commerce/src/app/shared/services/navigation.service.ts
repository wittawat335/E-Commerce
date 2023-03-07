import { Order, Payment } from './../models/payment-and-orders';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { PaymentMethod } from '../models/payment-and-orders';
import { Category } from '../models/product';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  private endpoint: string = environment.endpoint;
  private apiUrl: string = this.endpoint + 'api/Shopping/';
  // baseUrl = 'http://localhost:5121/api/Shopping/';

  constructor(private http: HttpClient) {}

  getCategoryList() {
    let url = this.apiUrl + 'GetCategoryList';
    return this.http.get<any[]>(url).pipe(
      map((categories) =>
        categories.map((category) => {
          let mappedCategory: Category = {
            id: category.id,
            category: category.category,
            subCategory: category.subCategory,
          };
          return mappedCategory;
        })
      )
    );
  }

  registerUser(user: User) {
    let url = this.apiUrl + 'RegisterUser';
    return this.http.post(url, user, { responseType: 'text' });
  }

  loginUser(email: string, password: string) {
    var body = { email, password };
    let url = this.apiUrl + 'LoginUser';
    return this.http.post(url, body, { responseType: 'text' });
  }

  getProducts(category: string, subCategory: string, count: number) {
    return this.http.get<any[]>(this.apiUrl + 'GetProducts', {
      params: new HttpParams()
        .set('category', category)
        .set('subCategory', subCategory)
        .set('count', count),
    });
  }

  getProduct(id: number) {
    let url = this.apiUrl + 'GetProduct/' + id;
    return this.http.get(url);
  }

  getActiveCartOfUser(userId: number) {
    let url = this.apiUrl + 'GetActiveCartOfUser/' + userId;
    return this.http.get(url);
  }

  getAllReviewsOfProduct(productId: number) {
    let url = this.apiUrl + 'GetProductReviews/' + productId;
    return this.http.get(url);
  }

  getAllPreviousCarts(userId: number) {
    let url = this.apiUrl + 'GetAllPreviousCartsOfUser/' + userId;
    return this.http.get(url);
  }

  addToCart(userId: number, productId: number) {
    let url = this.apiUrl + 'InsertCartItem/' + userId + '/' + productId;
    return this.http.post(url, null, { responseType: 'text' });
  }

  submitReview(userId: number, productId: number, review: string) {
    let obj: any = {
      User: {
        Id: userId,
      },
      Product: {
        Id: productId,
      },
      Value: review,
    };
    let url = this.apiUrl + 'InsertReview';
    return this.http.post(url, obj, { responseType: 'text' });
  }

  //Order && Payment
  getPaymentMethods() {
    let url = this.apiUrl + 'GetPaymentMethods';
    return this.http.get<PaymentMethod[]>(url);
  }
  insertPayment(payment: Payment) {
    return this.http.post(this.apiUrl + 'InsertPayment', payment, {
      responseType: 'text',
    });
  }
  insertOrder(order: Order) {
    return this.http.post(this.apiUrl + 'InsertOrder', order);
  }

  submitReview2() {
    let obj: any = {
      User: {
        Id: 1,
      },
      Product: {
        Id: 1,
      },
      Value: 'test',
    };
    let url = this.apiUrl + 'InsertPayment';
    return this.http.post(url, obj, { responseType: 'text' });
  }
}
