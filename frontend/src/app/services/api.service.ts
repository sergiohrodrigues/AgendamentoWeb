import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'https://localhost:7034/api';

  constructor(private http: HttpClient) {}
  
  loginUser(endpoint: string, body: any, options?: { params?: any; headers?: any }): Observable<any> {
    return this.http.post(`${this.apiUrl}/${endpoint}`, body, options);
  }
}
