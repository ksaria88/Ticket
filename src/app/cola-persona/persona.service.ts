import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ColaPersona } from './cola-persona';


@Injectable({
  providedIn: 'root'
})
export class ColaPersonaService {
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  apiUrl = 'api/ColaPersona';
  constructor(
    private http: HttpClient
  ) { }

  grabar(colaPersona: ColaPersona) {
    if (colaPersona.idColaPersona > 0) {
      return this.http.put<ColaPersona>(this.apiUrl + '/' + colaPersona.idColaPersona,
        JSON.stringify(colaPersona),
        { headers: this.headers });
    } else {
      return this.http.post<ColaPersona>(this.apiUrl,
        JSON.stringify(colaPersona)
        , { headers: this.headers });
    }
  }
}
