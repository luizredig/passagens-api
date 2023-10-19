import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Passagem } from '../../models/Passagem';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class PassagensService {
  apiUrl = 'http://localhost:5000/Passagem';
  constructor(private http: HttpClient) {}
  listar(): Observable<Passagem[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Passagem[]>(url);
  }
  buscar(id: number): Observable<Passagem> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Passagem>(url);
  }
  cadastrar(passagem: Passagem): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Passagem>(url, passagem, httpOptions);
  }
  atualizar(passagem: Passagem): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Passagem>(url, passagem, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
