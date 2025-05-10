import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DayWithTimes } from '../../interfaces/client/dayWithTimes';
import { Professional } from '../../interfaces/professional/professional';

export interface ResponseComDados<T> {
  dados: T;
}

@Injectable({
  providedIn: 'root'
})
export class ProfessionalService {

  private apiUrl = 'https://localhost:7034/api';

  constructor(private http: HttpClient) {}
  
  teste = 1;
  getAllProfessionals(teste: number): Observable<ResponseComDados<Professional[]>> {
    return this.http.get<ResponseComDados<Professional[]>>(`${this.apiUrl}/Professional/${teste}`);
  }
}
