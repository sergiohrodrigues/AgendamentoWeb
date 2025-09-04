import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayWithTimes } from '../../interfaces/dayWithTimes/dayWithTimes';
import { environment } from '../../environments/environment';

export interface ResponseComDados<T> {
  dados: T;
}

@Injectable({
  providedIn: 'root'
})
export class DayWithTimesService {

  constructor(private http: HttpClient) {}
  
  getDayWithTimes(profissionalId: number): Observable<DayWithTimes[]> {
    return this.http.get<DayWithTimes[]>(`${environment}/DayWithTimes/${profissionalId}`);
  }
}
