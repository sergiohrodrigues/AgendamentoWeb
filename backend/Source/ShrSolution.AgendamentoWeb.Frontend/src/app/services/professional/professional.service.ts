import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Professional } from '../../interfaces/professional/professional';
import { environment } from '../../environments/environment';

export interface ResponseComDados<T> {
  dados: T;
}

@Injectable({
  providedIn: 'root'
})
export class ProfessionalService {

  constructor(private http: HttpClient) {}
  
  teste = 1;
  getAllProfessionals(): Observable<ResponseComDados<Professional[]>> {
    return this.http.get<ResponseComDados<Professional[]>>(`${environment}/Profissional/${this.teste}`);
  }
}
