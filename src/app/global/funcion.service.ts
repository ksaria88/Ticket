import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Consulta } from './consulta';



@Injectable()
export class FuncionService {
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  apiUrl: string = "api/Funcion";

  constructor(private http: HttpClient) { }

  getDevolverString(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/DevolverString/',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

  getDevolverInt(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/DevolverInt/',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

  getDevolverBool(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/DevolverBool/',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

  getDevolverDouble(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/DevolverDouble/',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

  getEjecutarSql(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/EjecutarSql/',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

  getDevolverGrilla(consulta: Consulta) {
    return this.http.post<any>(this.apiUrl + '/DevolverLista',
      JSON.stringify(consulta)
      , { headers: this.headers });
  }

}
