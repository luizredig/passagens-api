import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanhiaAerea } from '../../models/CompanhiaAerea';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class CompanhiaAereasService {
  apiUrl = 'http://localhost:5000/CompanhiaAerea';
  constructor(private http: HttpClient) {}
  listar(): Observable<CompanhiaAerea[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<CompanhiaAerea[]>(url);
  }
  buscar(id: number): Observable<CompanhiaAerea> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<CompanhiaAerea>(url);
  }
  cadastrar(companhiaAerea: CompanhiaAerea): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<CompanhiaAerea>(url, companhiaAerea, httpOptions);
  }
  atualizar(companhiaAerea: CompanhiaAerea): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<CompanhiaAerea>(url, companhiaAerea, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
