import { HttpClient } from '@angular/common/http';
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
    let url = this.baseUrl + 'ProductCategories';
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

  /*   loginUser(email: string, password: string){
    let url =this.baseUrl + 'User'
  } */
}
