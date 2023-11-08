import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Passageiro } from '../../models/Passageiro';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class PassageirosService {
  apiUrl = 'http://localhost:5000/Passageiro';
  constructor(private http: HttpClient) {}
  listar(): Observable<Passageiro[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Passageiro[]>(url);
  }
  buscar(id: number): Observable<Passageiro> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Passageiro>(url);
  }
  cadastrar(passageiro: Passageiro): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Passageiro>(url, passageiro, httpOptions);
  }
  atualizar(passageiro: Passageiro): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Passageiro>(url, passageiro, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
