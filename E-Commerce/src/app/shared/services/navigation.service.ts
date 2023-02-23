import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Category } from '../models/product';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  baseUrl = 'http://localhost:5121/api/';

  constructor(private http: HttpClient) {}

  getCategoryList() {
    let url = this.baseUrl + 'Shopping/GetCategoryList';
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
    let url = this.baseUrl + 'User/Register';
    return this.http.post(url, user, { responseType: 'text' });
  }

  getProducts(category: string, subCategory: string, count: number) {
    return this.http.get<any[]>(this.baseUrl + 'Shopping/GetProducts', {
      params: new HttpParams()
        .set('category', category)
        .set('subCategory', subCategory)
        .set('count', count),
    });
  }

  /*   loginUser(email: string, password: string){
    let url =this.baseUrl + 'User'
  } */
}
