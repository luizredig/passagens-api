import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bagagem } from '../../models/Bagagem';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class BagagensService {
  apiUrl = 'http://localhost:5000/Bagagem';
  constructor(private http: HttpClient) {}
  listar(): Observable<Bagagem[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Bagagem[]>(url);
  }
  buscar(id: number): Observable<Bagagem> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Bagagem>(url);
  }
  cadastrar(bagagem: Bagagem): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Bagagem>(url, bagagem, httpOptions);
  }
  atualizar(bagagem: Bagagem): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Bagagem>(url, bagagem, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
