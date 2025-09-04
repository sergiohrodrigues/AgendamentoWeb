import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}
  
  loginUser(endpoint: string, body: any, options?: { params?: any; headers?: any }): Observable<any> {
    return this.http.post(`${environment}/${endpoint}`, body, options);
  }
}
