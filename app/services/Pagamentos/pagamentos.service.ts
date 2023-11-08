import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagamento } from '../../models/Pagamento';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class PagamentosService {
  apiUrl = 'http://localhost:5000/Pagamento';
  constructor(private http: HttpClient) {}
  listar(): Observable<Pagamento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pagamento[]>(url);
  }
  buscar(id: number): Observable<Pagamento> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Pagamento>(url);
  }
  cadastrar(pagamento: Pagamento): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pagamento>(url, pagamento, httpOptions);
  }
  atualizar(pagamento: Pagamento): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Pagamento>(url, pagamento, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
