import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/response-api';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private endpoint: string = environment.endpoint;
  private apiUrl: string = this.endpoint + 'api/Users';

  constructor(private http: HttpClient) {}

  getList(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.apiUrl);
  }

  add(request: User): Observable<ResponseApi> {
    return this.http.post<ResponseApi>(this.apiUrl, request);
  }

  update(request: User): Observable<ResponseApi> {
    return this.http.put<ResponseApi>(this.apiUrl, request);
  }

  delete(id: number): Observable<ResponseApi> {
    return this.http.delete<ResponseApi>(`${this.apiUrl}/${id}`);
  }
}
