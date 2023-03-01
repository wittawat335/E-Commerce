import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Category } from '../models/product';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  baseUrl = 'http://localhost:5121/api/Shopping/';

  constructor(private http: HttpClient) {}

  getCategoryList() {
    let url = this.baseUrl + 'GetCategoryList';
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
    console.log(user);
    let url = this.baseUrl + 'RegisterUser';
    return this.http.post(url, user, { responseType: 'text' });
  }

  loginUser(email: string, password: string) {
    let url = this.baseUrl + 'LoginUser';
    return this.http.post(
      url,
      { Email: email, Password: password },
      { responseType: 'text' }
    );
  }

  getProducts(category: string, subCategory: string, count: number) {
    return this.http.get<any[]>(this.baseUrl + 'GetProducts', {
      params: new HttpParams()
        .set('category', category)
        .set('subCategory', subCategory)
        .set('count', count),
    });
  }

  getProduct(id: number) {
    let url = this.baseUrl + 'GetProduct/' + id;
    return this.http.get(url);
  }

  getAllReviewsOfProduct(productId: number) {
    let url = this.baseUrl + 'GetProductReviews/' + productId;
    return this.http.get(url);
  }

  /*   loginUser(email: string, password: string){
    let url =this.baseUrl + 'User'
  } */
}
