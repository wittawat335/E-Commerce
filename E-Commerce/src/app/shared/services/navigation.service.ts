import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  baseUrl = 'http://localhost:5121/api/';

  constructor(private http: HttpClient) {}

  registerUser(user: User) {
    console.log(user);
    let url = this.baseUrl + 'Users/Register';
    return this.http.post(url, user, { responseType: 'text' });
  }
}
