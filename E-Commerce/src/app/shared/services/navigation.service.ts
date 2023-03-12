import { Order, Payment } from './../models/payment-and-orders';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { PaymentMethod } from '../models/payment-and-orders';
import { Category } from '../models/product';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { ResponseApi } from '../Interfaces/response-api';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  private endpoint: string = environment.endpoint;
  private apiUrl: string = this.endpoint + 'api/';
  // apiUrl = 'http://localhost:5121/api/Shopping/';

  constructor(private http: HttpClient) {}

  getCategoryList() {
    let url = this.apiUrl + 'Shopping/GetCategoryList';
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
    let url = this.apiUrl + 'Shopping/RegisterUser';
    return this.http.post(url, user, { responseType: 'text' });
  }

  loginUser(email: string, password: string) {
    var body = { email, password };
    let url = this.apiUrl + 'Shopping/LoginUser';
    return this.http.post(url, body, { responseType: 'text' });
  }

  getProducts(category: string, subCategory: string, count: number) {
    return this.http.get<any[]>(this.apiUrl + 'Shopping/GetProducts', {
      params: new HttpParams()
        .set('category', category)
        .set('subCategory', subCategory)
        .set('count', count),
    });
  }

  getProduct(id: number) {
    let url = this.apiUrl + 'Shopping/GetProduct/' + id;
    return this.http.get(url);
  }

  getActiveCartOfUser(userId: number) {
    let url = this.apiUrl + 'Shopping/GetActiveCartOfUser/' + userId;
    return this.http.get(url);
  }

  getAllReviewsOfProduct(productId: number) {
    let url = this.apiUrl + 'Shopping/GetProductReviews/' + productId;
    return this.http.get(url);
  }

  getAllPreviousCarts(userId: number) {
    let url = this.apiUrl + 'Shopping/GetAllPreviousCartsOfUser/' + userId;
    return this.http.get(url);
  }

  addToCart(userId: number, productId: number) {
    let url =
      this.apiUrl + 'Shopping/InsertCartItem/' + userId + '/' + productId;
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
    let url = this.apiUrl + 'Shopping/InsertReview';
    return this.http.post(url, obj, { responseType: 'text' });
  }

  //Order && Payment
  getPaymentMethods() {
    let url = this.apiUrl + 'Shopping/GetPaymentMethods';
    return this.http.get<PaymentMethod[]>(url);
  }
  insertPayment(payment: Payment) {
    return this.http.post(this.apiUrl + 'Shopping/InsertPayment', payment, {
      responseType: 'text',
    });
  }
  insertOrder(order: Order) {
    return this.http.post(this.apiUrl + 'Shopping/InsertOrder', order);
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
    let url = this.apiUrl + 'Shopping/InsertPayment';
    return this.http.post(url, obj, { responseType: 'text' });
  }
}
