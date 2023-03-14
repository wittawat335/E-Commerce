import { ResponseApi } from './../Interfaces/response-api';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  private endpoint: string = environment.endpoint;
  private apiUrl: string = this.endpoint + 'api/Departments';

  constructor(private http: HttpClient) {}
  getList(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.apiUrl);
  }

  getNameById(id: number): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.apiUrl}/${id}`);
  }
}
