import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aviao } from '../../models/Aviao';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class AvioesService {
  apiUrl = 'http://localhost:5000/Aviao';
  constructor(private http: HttpClient) {}
  listar(): Observable<Aviao[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Aviao[]>(url);
  }
  buscar(id: number): Observable<Aviao> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Aviao>(url);
  }
  cadastrar(aviao: Aviao): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Aviao>(url, aviao, httpOptions);
  }
  atualizar(aviao: Aviao): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Aviao>(url, aviao, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
