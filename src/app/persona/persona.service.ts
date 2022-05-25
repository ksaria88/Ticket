import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Persona } from './persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  apiUrl = 'api/Persona';
  constructor(
    private http: HttpClient
  ) { }

  grabar(persona: Persona) {
    if (persona.idPersona > 0) {
      return this.http.put<Persona>(this.apiUrl + '/' + persona.idPersona,
        JSON.stringify(persona),
        { headers: this.headers });
    } else {
      return this.http.post<Persona>(this.apiUrl,
        JSON.stringify(persona)
        , { headers: this.headers });
    }
  }
}
