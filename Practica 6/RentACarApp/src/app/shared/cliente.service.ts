import { Injectable } from '@angular/core';
import {Observable, of, throwError} from 'rxjs';
import {HttpClient, HttpHeaders, HttpRequest, HttpResponse} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { Storage } from '@ionic/storage-angular'

import {Cliente, Reserva} from './cliente.model';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Access-Control-Allow-Origin' : 'http://localhost:8100'
    })
  };

  const httpOptionsLogin = {
    headers: new HttpHeaders({'Content-Type':  'application/json'})
    //observe: 'response'
  };

@Injectable()

export class ClienteService {


  private readonly HS_API_URL = 'https://localhost:44358/api';
  private token : string = "";
  private headers = new HttpHeaders;


  constructor(private http: HttpClient,
    private storage: Storage) {


  }

  public RecuperarToken (){

    var promise = this.storage.get('token').then (token => {
      this.token = token;
      this.headers = new HttpHeaders ({'Authorization': this.token});
    });
    return promise;
  }



  public login(dni: string, password: string): Observable<any> {

    let cli:Cliente = {dni: dni, pass: password};

     return this.http.post(`${this.HS_API_URL}/Cliente_anonimo/Login`, cli, {responseType:'text'})
    .pipe(
        catchError((err) => {
          console.log("Error en el login");
          console.error(err);
          return throwError(err);
        }
        )
      );
  }

  public getClientePorDNI(token:string): Observable<Cliente>{

       this.headers = new HttpHeaders ({'Authorization': token});
       return this.http.get<Cliente>(`${this.HS_API_URL}/ClienteRegistrado`, {headers:this.headers});
   }

   public getReservas(idClienteRegistrado:string): Observable<Reserva[]>{
    //this.headers = new HttpHeaders ({'Authorization': token});

    return this.http.get<Reserva[]>(`${this.HS_API_URL}/Reserva/DameReservas?idClienteRegistrado=${idClienteRegistrado}`,  {headers:this.headers});
}
 }

