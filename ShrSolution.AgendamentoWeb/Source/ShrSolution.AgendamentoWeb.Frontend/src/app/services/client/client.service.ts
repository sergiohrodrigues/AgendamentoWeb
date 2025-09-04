import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayWithTimes } from '../../interfaces/dayWithTimes/dayWithTimes';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {


  constructor(private http: HttpClient) {}
  
  getDayWithTimes(endpoint: string): Observable<DayWithTimes[]> {
    return this.http.get<DayWithTimes[]>(`${environment}/${endpoint}`);
  }
}
