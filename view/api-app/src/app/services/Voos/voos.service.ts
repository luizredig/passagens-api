import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Voo } from '../../models/Voo';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class VoosService {
  apiUrl = 'http://localhost:5000/Voo';
  constructor(private http: HttpClient) {}
  listar(): Observable<Voo[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Voo[]>(url);
  }
  buscar(id: number): Observable<Voo> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Voo>(url);
  }
  cadastrar(voo: Voo): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Voo>(url, voo, httpOptions);
  }
  atualizar(voo: Voo): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Voo>(url, voo, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
