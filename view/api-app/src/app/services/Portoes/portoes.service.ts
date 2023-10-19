import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Portao } from '../../models/Portao';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class PortoesService {
  apiUrl = 'http://localhost:5000/Portao';
  constructor(private http: HttpClient) {}
  listar(): Observable<Portao[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Portao[]>(url);
  }
  buscar(id: number): Observable<Portao> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Portao>(url);
  }
  cadastrar(portao: Portao): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Portao>(url, portao, httpOptions);
  }
  atualizar(portao: Portao): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Portao>(url, portao, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
