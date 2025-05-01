import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayWithTimes } from '../../interfaces/client/dayWithTimes';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private apiUrl = 'https://localhost:7034/api';

  constructor(private http: HttpClient) {}
  
  getDayWithTimes(endpoint: string): Observable<DayWithTimes[]> {
    return this.http.get<DayWithTimes[]>(`${this.apiUrl}/${endpoint}`);
  }
}
