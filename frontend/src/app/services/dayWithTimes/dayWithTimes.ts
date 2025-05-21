import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayWithTimes } from '../../interfaces/dayWithTimes/dayWithTimes';

export interface ResponseComDados<T> {
  dados: T;
}

@Injectable({
  providedIn: 'root'
})
export class DayWithTimesService {

  private apiUrl = 'https://localhost:7034/api';

  constructor(private http: HttpClient) {}
  
  getDayWithTimes(profissionalId: number): Observable<DayWithTimes[]> {
    return this.http.get<DayWithTimes[]>(`${this.apiUrl}/DayWithTimes/${profissionalId}`);
  }
}
