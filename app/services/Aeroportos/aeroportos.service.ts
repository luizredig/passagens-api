import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aeroporto } from '../../models/Aeroporto';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class AeroportosService {
  apiUrl = 'http://localhost:5000/Aeroporto';
  constructor(private http: HttpClient) {}
  listar(): Observable<Aeroporto[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Aeroporto[]>(url);
  }
  buscar(id: number): Observable<Aeroporto> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Aeroporto>(url);
  }
  cadastrar(aeroporto: Aeroporto): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Aeroporto>(url, aeroporto, httpOptions);
  }
  atualizar(aeroporto: Aeroporto): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Aeroporto>(url, aeroporto, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
